namespace Hypex.Domain.Entities;

/// <summary>Product category (laptops, tablets, phones, gadgets, headsets).</summary>
public class Category
{
    public int Id { get; set; }
    public string Slug { get; set; } = null!;

    /// <summary>Localized display names keyed by language code (ru/uz/en).</summary>
    public ICollection<CategoryTranslation> Translations { get; set; } = new List<CategoryTranslation>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

/// <summary>Localized category name.</summary>
public class CategoryTranslation
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public string Lang { get; set; } = null!;
    public string Name { get; set; } = null!;
}
