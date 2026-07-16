namespace Hypex.Infrastructure.Persistence.Seed;

/// <summary>Plain data shapes describing the seed catalog before it is materialized into entities.</summary>
internal record LocalizedText(string Ru, string Uz, string En)
{
    public string For(string lang) => lang switch
    {
        "uz" => Uz,
        "en" => En,
        _ => Ru,
    };
}

internal record CategorySeed(int Id, string Slug, LocalizedText Name);

internal record BrandSeed(int Id, string Slug, string Name, string? LogoUrl = null);

/// <summary>An attribute row shared across languages: a stable key + a localized label + localized values.</summary>
internal record AttributeSeed(string Key, LocalizedText Label, LocalizedText Value);

internal record ProductSeed(
    string Slug,
    int CategoryId,
    int BrandId,
    decimal Price,
    int Stock,
    LocalizedText Name,
    LocalizedText Description,
    IReadOnlyList<string> ImageUrls,
    IReadOnlyList<AttributeSeed> Attributes,
    double RatingAverage = 0,
    int RatingCount = 0);
