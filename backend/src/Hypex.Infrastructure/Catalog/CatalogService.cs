using Hypex.Application.Catalog;
using Hypex.Application.Common;
using Hypex.Domain.Common;
using Hypex.Domain.Entities;
using Hypex.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hypex.Infrastructure.Catalog;

public class CatalogService(HypexDbContext db, ILanguageContext lang) : ICatalogService
{
    private string Lang => lang.Current;
    private const string Fallback = Languages.Ru;

    public async Task<PagedResult<ProductListItemDto>> GetProductsAsync(ProductQuery q, CancellationToken ct = default)
    {
        var page = q.Page < 1 ? 1 : q.Page;
        var pageSize = q.PageSize is < 1 or > 60 ? 12 : q.PageSize;

        var query = db.Products
            .AsNoTracking()
            .Where(p => p.IsActive);

        if (!string.IsNullOrWhiteSpace(q.Category))
            query = query.Where(p => p.Category.Slug == q.Category);

        if (!string.IsNullOrWhiteSpace(q.Brand))
            query = query.Where(p => p.Brand.Slug == q.Brand);

        if (q.MinPrice is { } min)
            query = query.Where(p => p.Price >= min);

        if (q.MaxPrice is { } max)
            query = query.Where(p => p.Price <= max);

        if (q.InStock == true)
            query = query.Where(p => p.Stock > 0);

        if (q.OnSale == true)
            query = query.Where(p => p.OldPrice != null && p.OldPrice > p.Price);

        if (!string.IsNullOrWhiteSpace(q.Search))
        {
            var term = q.Search.Trim().ToLower();
            query = query.Where(p =>
                p.Brand.Name.ToLower().Contains(term) ||
                p.Translations.Any(t => t.Name.ToLower().Contains(term) ||
                                        t.Description.ToLower().Contains(term)));
        }

        query = q.Sort switch
        {
            "price_asc" => query.OrderBy(p => p.Price),
            "price_desc" => query.OrderByDescending(p => p.Price),
            "rating" => query.OrderByDescending(p => p.RatingAverage).ThenByDescending(p => p.RatingCount),
            "discount" => query
                .OrderByDescending(p => p.OldPrice != null && p.OldPrice > p.Price
                    ? (p.OldPrice.Value - p.Price) / p.OldPrice.Value
                    : 0m)
                .ThenByDescending(p => p.CreatedAt),
            "name" => query.OrderBy(p => p.Translations
                .Where(t => t.Lang == Lang).Select(t => t.Name).FirstOrDefault()),
            _ => query.OrderByDescending(p => p.CreatedAt),
        };

        var total = await query.CountAsync(ct);

        var lang = Lang;
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new ProductListItemDto(
                p.Id,
                p.Slug,
                p.Translations.Where(t => t.Lang == lang).Select(t => t.Name).FirstOrDefault()
                    ?? p.Translations.Where(t => t.Lang == Fallback).Select(t => t.Name).FirstOrDefault()
                    ?? p.Slug,
                p.Price,
                p.OldPrice != null && p.OldPrice > p.Price ? p.OldPrice : null,
                p.OldPrice != null && p.OldPrice > p.Price
                    ? (int)Math.Round((p.OldPrice.Value - p.Price) / p.OldPrice.Value * 100)
                    : 0,
                p.Stock,
                p.Stock > 0,
                p.RatingAverage,
                p.RatingCount,
                p.Category.Slug,
                p.Brand.Name,
                p.ImageUrls.FirstOrDefault()))
            .ToListAsync(ct);

        return new PagedResult<ProductListItemDto>(items, page, pageSize, total);
    }

    public async Task<ProductDetailDto?> GetProductBySlugAsync(string slug, CancellationToken ct = default)
    {
        var lang = Lang;
        var p = await db.Products
            .AsNoTracking()
            .Include(x => x.Category).ThenInclude(c => c.Translations)
            .Include(x => x.Brand)
            .Include(x => x.Translations)
            .Include(x => x.Attributes)
            .FirstOrDefaultAsync(x => x.Slug == slug && x.IsActive, ct);

        if (p is null)
            return null;

        var tr = Pick(p.Translations, lang);
        var catName = Pick(p.Category.Translations, lang)?.Name ?? p.Category.Slug;

        var attributes = p.Attributes
            .Where(a => a.Lang == lang)
            .OrderBy(a => a.SortOrder)
            .Select(a => new ProductAttributeDto(a.Key, a.Label, a.Value))
            .ToList();

        // Fall back to RU attributes if the requested language has none.
        if (attributes.Count == 0)
        {
            attributes = p.Attributes
                .Where(a => a.Lang == Fallback)
                .OrderBy(a => a.SortOrder)
                .Select(a => new ProductAttributeDto(a.Key, a.Label, a.Value))
                .ToList();
        }

        var onSale = p.OldPrice is { } oldPrice && oldPrice > p.Price;
        var discountPercent = onSale
            ? (int)Math.Round((p.OldPrice!.Value - p.Price) / p.OldPrice.Value * 100)
            : 0;

        return new ProductDetailDto(
            p.Id,
            p.Slug,
            tr?.Name ?? p.Slug,
            tr?.Description ?? string.Empty,
            p.Price,
            onSale ? p.OldPrice : null,
            discountPercent,
            p.Stock,
            p.Stock > 0,
            p.RatingAverage,
            p.RatingCount,
            p.Category.Slug,
            catName,
            p.Brand.Slug,
            p.Brand.Name,
            p.ImageUrls,
            attributes);
    }

    public async Task<IReadOnlyList<CategoryDto>> GetCategoriesAsync(CancellationToken ct = default)
    {
        var lang = Lang;
        return await db.Categories
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .Select(c => new CategoryDto(
                c.Id,
                c.Slug,
                c.Translations.Where(t => t.Lang == lang).Select(t => t.Name).FirstOrDefault()
                    ?? c.Translations.Where(t => t.Lang == Fallback).Select(t => t.Name).FirstOrDefault()
                    ?? c.Slug,
                c.Products.Count(p => p.IsActive)))
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<BrandDto>> GetBrandsAsync(CancellationToken ct = default)
    {
        return await db.Brands
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .Select(b => new BrandDto(b.Id, b.Slug, b.Name, b.LogoUrl))
            .ToListAsync(ct);
    }

    private static ProductTranslation? Pick(IEnumerable<ProductTranslation> translations, string lang) =>
        translations.FirstOrDefault(t => t.Lang == lang)
        ?? translations.FirstOrDefault(t => t.Lang == Fallback);

    private static CategoryTranslation? Pick(IEnumerable<CategoryTranslation> translations, string lang) =>
        translations.FirstOrDefault(t => t.Lang == lang)
        ?? translations.FirstOrDefault(t => t.Lang == Fallback);
}
