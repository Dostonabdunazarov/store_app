namespace Hypex.Domain.Entities;

/// <summary>Manufacturer / brand (Apple, Samsung, Sony…). Brand names are not localized.</summary>
public class Brand
{
    public int Id { get; set; }
    public string Slug { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? LogoUrl { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
