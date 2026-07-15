namespace Hypex.Domain.Entities;

/// <summary>A sellable product (laptop, phone, gadget…).</summary>
public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Slug { get; set; } = null!;

    /// <summary>Price in the store's base currency (USD), two decimals.</summary>
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public int BrandId { get; set; }
    public Brand Brand { get; set; } = null!;

    /// <summary>Image URLs (first is the primary/cover image).</summary>
    public List<string> ImageUrls { get; set; } = new();

    /// <summary>Denormalized rating cache, recomputed on review changes (Phase 2).</summary>
    public double RatingAverage { get; set; }
    public int RatingCount { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<ProductTranslation> Translations { get; set; } = new List<ProductTranslation>();
    public ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
