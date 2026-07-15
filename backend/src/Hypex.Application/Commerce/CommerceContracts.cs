using Hypex.Domain.Common;
using Hypex.Domain.Entities;

namespace Hypex.Application.Commerce;

public record FavoriteDto(Guid ProductId, string Slug, string Name, decimal Price, string? ImageUrl, DateTime CreatedAt);
public record ReviewDto(Guid Id, Guid ProductId, Guid UserId, string UserName, int Rating, string? Comment, DateTime CreatedAt);
public record CreateReviewRequest(int Rating, string? Comment);
public record OrderItemRequest(Guid ProductId, int Quantity);
public record CreateOrderRequest(string ContactName, string ContactPhone, string ShippingCity, string ShippingAddress, string? Comment, IReadOnlyList<OrderItemRequest> Items);
public record OrderItemDto(Guid? ProductId, string ProductName, string? ProductImageUrl, decimal UnitPrice, int Quantity, decimal LineTotal);
public record OrderDto(Guid Id, OrderStatus Status, string ContactName, string ContactPhone, string ShippingCity, string ShippingAddress, string? Comment, decimal TotalAmount, DateTime CreatedAt, DateTime UpdatedAt, IReadOnlyList<OrderItemDto> Items);

public record ProductTranslationDto(string Lang, string Name, string Description);
public record ProductAttributeInput(string Lang, string Key, string Label, string Value, int SortOrder);
public record ProductUpsertRequest(
    string Slug,
    decimal Price,
    int Stock,
    int CategoryId,
    int BrandId,
    IReadOnlyList<string> ImageUrls,
    IReadOnlyList<ProductTranslationDto> Translations,
    IReadOnlyList<ProductAttributeInput> Attributes,
    bool IsActive = true);

/// <summary>Full product view for the admin editor — all languages, all attributes, incl. inactive.</summary>
public record AdminProductDto(
    Guid Id,
    string Slug,
    decimal Price,
    int Stock,
    int CategoryId,
    int BrandId,
    string CategorySlug,
    string BrandName,
    IReadOnlyList<string> ImageUrls,
    double RatingAverage,
    int RatingCount,
    bool IsActive,
    DateTime CreatedAt,
    IReadOnlyList<ProductTranslationDto> Translations,
    IReadOnlyList<ProductAttributeInput> Attributes);

public record CategoryUpsertRequest(string Slug, IReadOnlyDictionary<string, string> Names);
public record BrandUpsertRequest(string Slug, string Name, string? LogoUrl);
public record UpdateOrderStatusRequest(OrderStatus Status);

/// <summary>Flat category view returned by admin create/update (no navigation cycles). Name is the RU translation.</summary>
public record AdminCategoryDto(int Id, string Slug, string Name);
public record AdminBrandDto(int Id, string Slug, string Name, string? LogoUrl);

public interface ICommerceService
{
    Task<IReadOnlyList<FavoriteDto>> GetFavoritesAsync(Guid userId, CancellationToken ct = default);
    Task AddFavoriteAsync(Guid userId, Guid productId, CancellationToken ct = default);
    Task RemoveFavoriteAsync(Guid userId, Guid productId, CancellationToken ct = default);
    Task<IReadOnlyList<ReviewDto>> GetReviewsAsync(Guid productId, CancellationToken ct = default);
    Task<ReviewDto> AddReviewAsync(Guid userId, Guid productId, CreateReviewRequest request, CancellationToken ct = default);
    Task<OrderDto> CreateOrderAsync(Guid userId, CreateOrderRequest request, CancellationToken ct = default);
    Task<IReadOnlyList<OrderDto>> GetOrdersAsync(Guid userId, CancellationToken ct = default);
    Task<OrderDto?> GetOrderAsync(Guid userId, Guid orderId, bool admin = false, CancellationToken ct = default);
    Task<IReadOnlyList<OrderDto>> GetAllOrdersAsync(CancellationToken ct = default);
    Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status, CancellationToken ct = default);
    Task<IReadOnlyList<AdminProductDto>> GetAdminProductsAsync(CancellationToken ct = default);
    Task<AdminProductDto?> GetAdminProductAsync(Guid id, CancellationToken ct = default);
    Task<AdminProductDto> CreateProductAsync(ProductUpsertRequest request, CancellationToken ct = default);
    Task<AdminProductDto?> UpdateProductAsync(Guid id, ProductUpsertRequest request, CancellationToken ct = default);
    Task DeleteProductAsync(Guid id, CancellationToken ct = default);
    Task<AdminCategoryDto> CreateCategoryAsync(CategoryUpsertRequest request, CancellationToken ct = default);
    Task<AdminBrandDto> CreateBrandAsync(BrandUpsertRequest request, CancellationToken ct = default);
    Task<AdminCategoryDto?> UpdateCategoryAsync(int id, CategoryUpsertRequest request, CancellationToken ct = default);
    Task DeleteCategoryAsync(int id, CancellationToken ct = default);
    Task<AdminBrandDto?> UpdateBrandAsync(int id, BrandUpsertRequest request, CancellationToken ct = default);
    Task DeleteBrandAsync(int id, CancellationToken ct = default);
}
