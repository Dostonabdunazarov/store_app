namespace Hypex.Application.Catalog;

/// <summary>Read-only catalog queries (localized by the current request language).</summary>
public interface ICatalogService
{
    Task<PagedResult<ProductListItemDto>> GetProductsAsync(ProductQuery query, CancellationToken ct = default);
    Task<ProductDetailDto?> GetProductBySlugAsync(string slug, CancellationToken ct = default);
    Task<IReadOnlyList<CategoryDto>> GetCategoriesAsync(CancellationToken ct = default);
    Task<IReadOnlyList<BrandDto>> GetBrandsAsync(CancellationToken ct = default);
}
