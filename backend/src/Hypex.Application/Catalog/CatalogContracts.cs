namespace Hypex.Application.Catalog;

/// <summary>Paged result envelope.</summary>
public record PagedResult<T>(IReadOnlyList<T> Items, int Page, int PageSize, int TotalCount)
{
    public int TotalPages => PageSize <= 0 ? 0 : (int)Math.Ceiling(TotalCount / (double)PageSize);
}

/// <summary>Query parameters for the product listing endpoint.</summary>
public class ProductQuery
{
    public string? Search { get; set; }
    public string? Category { get; set; }   // category slug
    public string? Brand { get; set; }       // brand slug (single)
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public bool? InStock { get; set; }

    /// <summary>When true, only products currently on sale (with a discount) are returned.</summary>
    public bool? OnSale { get; set; }

    /// <summary>Sort key: "newest" (default), "price_asc", "price_desc", "rating", "name", "discount".</summary>
    public string? Sort { get; set; }

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 12;
}

/// <summary>Compact product card for listing/grid views.</summary>
public record ProductListItemDto(
    Guid Id,
    string Slug,
    string Name,
    decimal Price,
    decimal? OldPrice,
    int DiscountPercent,
    int Stock,
    bool InStock,
    double RatingAverage,
    int RatingCount,
    string CategorySlug,
    string BrandName,
    string? ImageUrl);

public record ProductAttributeDto(string Key, string Label, string Value);

/// <summary>Full product detail for the product page.</summary>
public record ProductDetailDto(
    Guid Id,
    string Slug,
    string Name,
    string Description,
    decimal Price,
    decimal? OldPrice,
    int DiscountPercent,
    int Stock,
    bool InStock,
    double RatingAverage,
    int RatingCount,
    string CategorySlug,
    string CategoryName,
    string BrandSlug,
    string BrandName,
    IReadOnlyList<string> ImageUrls,
    IReadOnlyList<ProductAttributeDto> Attributes);

public record CategoryDto(int Id, string Slug, string Name, int ProductCount);

public record BrandDto(int Id, string Slug, string Name, string? LogoUrl);
