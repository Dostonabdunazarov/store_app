using Hypex.Application.Common;
using Hypex.Application.Commerce;
using Hypex.Domain.Common;
using Hypex.Domain.Entities;
using Hypex.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hypex.Infrastructure.Commerce;

public class CommerceService(HypexDbContext db) : ICommerceService
{
    public async Task<IReadOnlyList<FavoriteDto>> GetFavoritesAsync(Guid userId, CancellationToken ct = default) => await db.Favorites.AsNoTracking().Where(f => f.UserId == userId).OrderByDescending(f => f.CreatedAt).Select(f => new FavoriteDto(f.ProductId, f.Product.Slug, f.Product.Translations.OrderBy(t => t.Lang == "ru" ? 0 : 1).Select(t => t.Name).FirstOrDefault() ?? f.Product.Slug, f.Product.Price, f.Product.ImageUrls.FirstOrDefault(), f.CreatedAt)).ToListAsync(ct);
    public async Task AddFavoriteAsync(Guid userId, Guid productId, CancellationToken ct = default) { if (!await db.Products.AnyAsync(p => p.Id == productId && p.IsActive, ct)) throw AppException.NotFound("Product not found."); if (!await db.Favorites.AnyAsync(f => f.UserId == userId && f.ProductId == productId, ct)) { db.Favorites.Add(new Favorite { UserId = userId, ProductId = productId }); await db.SaveChangesAsync(ct); } }
    public async Task RemoveFavoriteAsync(Guid userId, Guid productId, CancellationToken ct = default) { var f = await db.Favorites.FindAsync([userId, productId], ct); if (f is null) throw AppException.NotFound("Favorite not found."); db.Favorites.Remove(f); await db.SaveChangesAsync(ct); }
    public async Task<IReadOnlyList<ReviewDto>> GetReviewsAsync(Guid productId, CancellationToken ct = default) => await db.Reviews.AsNoTracking().Where(r => r.ProductId == productId).OrderByDescending(r => r.CreatedAt).Select(r => new ReviewDto(r.Id, r.ProductId, r.UserId, r.User.FullName, r.Rating, r.Comment, r.CreatedAt)).ToListAsync(ct);
    public async Task<ReviewDto> AddReviewAsync(Guid userId, Guid productId, CreateReviewRequest request, CancellationToken ct = default)
    {
        if (!await db.Products.AnyAsync(p => p.Id == productId && p.IsActive, ct)) throw AppException.NotFound("Product not found.");
        if (await db.Reviews.AnyAsync(r => r.ProductId == productId && r.UserId == userId, ct)) throw AppException.Conflict("You have already reviewed this product.");
        var review = new Review { ProductId = productId, UserId = userId, Rating = request.Rating, Comment = request.Comment?.Trim() };
        db.Reviews.Add(review); await db.SaveChangesAsync(ct); await RecalculateRatingAsync(productId, ct);
        var user = await db.Users.FindAsync([userId], ct); return new ReviewDto(review.Id, productId, userId, user!.FullName, review.Rating, review.Comment, review.CreatedAt);
    }
    public async Task<OrderDto> CreateOrderAsync(Guid userId, CreateOrderRequest request, CancellationToken ct = default)
    {
        if (request.Items is null || request.Items.Count == 0) throw AppException.BadRequest("Order must contain at least one item.");
        var ids = request.Items.Select(x => x.ProductId).Distinct().ToArray(); var products = await db.Products.Where(p => ids.Contains(p.Id) && p.IsActive).Include(p => p.Translations).ToDictionaryAsync(p => p.Id, ct);
        if (products.Count != ids.Length) throw AppException.BadRequest("One or more products are unavailable.");
        var order = new Order { UserId = userId, ContactName = request.ContactName.Trim(), ContactPhone = request.ContactPhone.Trim(), ShippingCity = request.ShippingCity.Trim(), ShippingAddress = request.ShippingAddress.Trim(), Comment = request.Comment?.Trim() };
        foreach (var line in request.Items) { if (line.Quantity is < 1 or > 99) throw AppException.BadRequest("Quantity must be between 1 and 99."); var p = products[line.ProductId]; if (p.Stock < line.Quantity) throw AppException.BadRequest($"Insufficient stock for '{p.Slug}'."); var name = p.Translations.FirstOrDefault(t => t.Lang == "ru")?.Name ?? p.Slug; order.Items.Add(new OrderItem { ProductId = p.Id, ProductName = name, ProductImageUrl = p.ImageUrls.FirstOrDefault(), UnitPrice = p.Price, Quantity = line.Quantity }); p.Stock -= line.Quantity; }
        order.TotalAmount = order.Items.Sum(i => i.UnitPrice * i.Quantity); db.Orders.Add(order); await db.SaveChangesAsync(ct); return ToDto(order);
    }
    public async Task<IReadOnlyList<OrderDto>> GetOrdersAsync(Guid userId, CancellationToken ct = default) => (await db.Orders.AsNoTracking().Include(o => o.Items).Where(o => o.UserId == userId).OrderByDescending(o => o.CreatedAt).ToListAsync(ct)).Select(ToDto).ToList();
    public async Task<OrderDto?> GetOrderAsync(Guid userId, Guid orderId, bool admin = false, CancellationToken ct = default) { var o = await db.Orders.AsNoTracking().Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == orderId && (admin || x.UserId == userId), ct); return o is null ? null : ToDto(o); }
    public async Task<IReadOnlyList<OrderDto>> GetAllOrdersAsync(CancellationToken ct = default) => (await db.Orders.AsNoTracking().Include(o => o.Items).OrderByDescending(o => o.CreatedAt).ToListAsync(ct)).Select(ToDto).ToList();
    public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status, CancellationToken ct = default) { var o = await db.Orders.FindAsync([orderId], ct) ?? throw AppException.NotFound("Order not found."); o.Status = status; o.UpdatedAt = DateTime.UtcNow; await db.SaveChangesAsync(ct); }
    public async Task<IReadOnlyList<AdminProductDto>> GetAdminProductsAsync(CancellationToken ct = default) => (await db.Products.AsNoTracking().Include(p => p.Category).Include(p => p.Brand).Include(p => p.Translations).Include(p => p.Attributes).OrderByDescending(p => p.CreatedAt).ToListAsync(ct)).Select(ToAdminDto).ToList();
    public async Task<AdminProductDto?> GetAdminProductAsync(Guid id, CancellationToken ct = default) { var p = await db.Products.AsNoTracking().Include(x => x.Category).Include(x => x.Brand).Include(x => x.Translations).Include(x => x.Attributes).FirstOrDefaultAsync(x => x.Id == id, ct); return p is null ? null : ToAdminDto(p); }
    public async Task<AdminProductDto> CreateProductAsync(ProductUpsertRequest r, CancellationToken ct = default)
    {
        await EnsureRefsAsync(r, ct);
        if (await db.Products.AnyAsync(p => p.Slug == r.Slug.Trim(), ct)) throw AppException.Conflict("A product with this slug already exists.");
        var p = new Product { Slug = r.Slug.Trim(), Price = r.Price, OldPrice = r.OldPrice, Stock = r.Stock, CategoryId = r.CategoryId, BrandId = r.BrandId, ImageUrls = r.ImageUrls.ToList(), IsActive = r.IsActive };
        ApplyTranslations(p, r); ApplyAttributes(p, r);
        db.Products.Add(p); await db.SaveChangesAsync(ct);
        return (await GetAdminProductAsync(p.Id, ct))!;
    }
    public async Task<AdminProductDto?> UpdateProductAsync(Guid id, ProductUpsertRequest r, CancellationToken ct = default)
    {
        // Track only the product scalars; children are replaced with set-based delete + insert so
        // the tracked graph never holds both the removed and the re-added rows (which caused an
        // UPDATE-on-deleted-key concurrency conflict).
        var p = await db.Products.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (p is null) return null;
        await EnsureRefsAsync(r, ct);
        if (await db.Products.AnyAsync(x => x.Slug == r.Slug.Trim() && x.Id != id, ct)) throw AppException.Conflict("A product with this slug already exists.");
        p.Slug = r.Slug.Trim(); p.Price = r.Price; p.OldPrice = r.OldPrice; p.Stock = r.Stock; p.CategoryId = r.CategoryId; p.BrandId = r.BrandId; p.ImageUrls = r.ImageUrls.ToList(); p.IsActive = r.IsActive;
        await db.ProductTranslations.Where(t => t.ProductId == id).ExecuteDeleteAsync(ct);
        await db.ProductAttributes.Where(a => a.ProductId == id).ExecuteDeleteAsync(ct);
        db.ProductTranslations.AddRange(r.Translations.Select(t => new ProductTranslation { ProductId = id, Lang = t.Lang, Name = t.Name.Trim(), Description = (t.Description ?? string.Empty).Trim() }));
        db.ProductAttributes.AddRange(r.Attributes.Select(a => new ProductAttribute { ProductId = id, Lang = a.Lang, Key = a.Key.Trim(), Label = a.Label.Trim(), Value = a.Value.Trim(), SortOrder = a.SortOrder }));
        await db.SaveChangesAsync(ct);
        return await GetAdminProductAsync(id, ct);
    }
    public async Task DeleteProductAsync(Guid id, CancellationToken ct = default) { var p = await db.Products.FindAsync([id], ct) ?? throw AppException.NotFound("Product not found."); p.IsActive = false; await db.SaveChangesAsync(ct); }

    private async Task EnsureRefsAsync(ProductUpsertRequest r, CancellationToken ct)
    {
        if (!await db.Categories.AnyAsync(c => c.Id == r.CategoryId, ct)) throw AppException.BadRequest("Category not found.");
        if (!await db.Brands.AnyAsync(b => b.Id == r.BrandId, ct)) throw AppException.BadRequest("Brand not found.");
    }
    private static void ApplyTranslations(Product p, ProductUpsertRequest r) { foreach (var t in r.Translations) p.Translations.Add(new ProductTranslation { ProductId = p.Id, Lang = t.Lang, Name = t.Name.Trim(), Description = (t.Description ?? string.Empty).Trim() }); }
    private static void ApplyAttributes(Product p, ProductUpsertRequest r) { foreach (var a in r.Attributes) p.Attributes.Add(new ProductAttribute { ProductId = p.Id, Lang = a.Lang, Key = a.Key.Trim(), Label = a.Label.Trim(), Value = a.Value.Trim(), SortOrder = a.SortOrder }); }
    private static AdminProductDto ToAdminDto(Product p) => new(p.Id, p.Slug, p.Price, p.OldPrice, p.Stock, p.CategoryId, p.BrandId, p.Category.Slug, p.Brand.Name, p.ImageUrls, p.RatingAverage, p.RatingCount, p.IsActive, p.CreatedAt, p.Translations.Select(t => new ProductTranslationDto(t.Lang, t.Name, t.Description)).ToList(), p.Attributes.OrderBy(a => a.SortOrder).Select(a => new ProductAttributeInput(a.Lang, a.Key, a.Label, a.Value, a.SortOrder)).ToList());
    public async Task<AdminCategoryDto> CreateCategoryAsync(CategoryUpsertRequest r, CancellationToken ct = default) { var c = new Category { Slug = r.Slug.Trim() }; foreach (var n in r.Names) c.Translations.Add(new CategoryTranslation { Lang = n.Key, Name = n.Value.Trim() }); db.Categories.Add(c); await db.SaveChangesAsync(ct); return ToAdminCategoryDto(c); }
    public async Task<AdminBrandDto> CreateBrandAsync(BrandUpsertRequest r, CancellationToken ct = default) { var b = new Brand { Slug = r.Slug.Trim(), Name = r.Name.Trim(), LogoUrl = r.LogoUrl }; db.Brands.Add(b); await db.SaveChangesAsync(ct); return new AdminBrandDto(b.Id, b.Slug, b.Name, b.LogoUrl); }
    public async Task<AdminCategoryDto?> UpdateCategoryAsync(int id, CategoryUpsertRequest r, CancellationToken ct = default) { var c = await db.Categories.FirstOrDefaultAsync(x => x.Id == id, ct); if (c is null) return null; c.Slug = r.Slug.Trim(); await db.CategoryTranslations.Where(t => t.CategoryId == id).ExecuteDeleteAsync(ct); db.CategoryTranslations.AddRange(r.Names.Select(n => new CategoryTranslation { CategoryId = id, Lang = n.Key, Name = n.Value.Trim() })); await db.SaveChangesAsync(ct); return ToAdminCategoryDto(c, r.Names); }
    public async Task DeleteCategoryAsync(int id, CancellationToken ct = default) { var c = await db.Categories.FindAsync([id], ct) ?? throw AppException.NotFound("Category not found."); if (await db.Products.AnyAsync(p => p.CategoryId == id, ct)) throw AppException.Conflict("Category contains products."); db.Categories.Remove(c); await db.SaveChangesAsync(ct); }
    public async Task<AdminBrandDto?> UpdateBrandAsync(int id, BrandUpsertRequest r, CancellationToken ct = default) { var b = await db.Brands.FindAsync([id], ct); if (b is null) return null; b.Slug = r.Slug.Trim(); b.Name = r.Name.Trim(); b.LogoUrl = r.LogoUrl; await db.SaveChangesAsync(ct); return new AdminBrandDto(b.Id, b.Slug, b.Name, b.LogoUrl); }
    private static AdminCategoryDto ToAdminCategoryDto(Category c, IReadOnlyDictionary<string, string>? names = null) { var name = names is not null ? (names.TryGetValue(Languages.Ru, out var ru) ? ru : names.Values.FirstOrDefault() ?? c.Slug) : (c.Translations.FirstOrDefault(t => t.Lang == Languages.Ru)?.Name ?? c.Translations.FirstOrDefault()?.Name ?? c.Slug); return new AdminCategoryDto(c.Id, c.Slug, name.Trim()); }
    public async Task DeleteBrandAsync(int id, CancellationToken ct = default) { var b = await db.Brands.FindAsync([id], ct) ?? throw AppException.NotFound("Brand not found."); if (await db.Products.AnyAsync(p => p.BrandId == id, ct)) throw AppException.Conflict("Brand contains products."); db.Brands.Remove(b); await db.SaveChangesAsync(ct); }
    private async Task RecalculateRatingAsync(Guid id, CancellationToken ct) { var p = await db.Products.FindAsync([id], ct); if (p is null) return; var q = db.Reviews.Where(r => r.ProductId == id); p.RatingCount = await q.CountAsync(ct); p.RatingAverage = p.RatingCount == 0 ? 0 : await q.AverageAsync(r => (double)r.Rating, ct); await db.SaveChangesAsync(ct); }
    private static OrderDto ToDto(Order o) => new(o.Id, o.Status, o.ContactName, o.ContactPhone, o.ShippingCity, o.ShippingAddress, o.Comment, o.TotalAmount, o.CreatedAt, o.UpdatedAt, o.Items.Select(i => new OrderItemDto(i.ProductId, i.ProductName, i.ProductImageUrl, i.UnitPrice, i.Quantity, i.UnitPrice * i.Quantity)).ToList());
}
