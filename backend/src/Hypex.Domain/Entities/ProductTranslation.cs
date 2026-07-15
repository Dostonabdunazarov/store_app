namespace Hypex.Domain.Entities;

/// <summary>Localized product name and description (ru/uz/en).</summary>
public class ProductTranslation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public string Lang { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
