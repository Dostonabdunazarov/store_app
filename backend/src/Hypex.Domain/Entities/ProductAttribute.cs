namespace Hypex.Domain.Entities;

/// <summary>
/// A key/value spec used for filtering and side-by-side comparison
/// (e.g. RAM=16GB, Screen=6.1", CPU=Apple A17 Pro).
/// The <see cref="Key"/> is a stable machine slug; <see cref="Label"/> and
/// <see cref="Value"/> are display strings localized via <see cref="Lang"/>.
/// </summary>
public class ProductAttribute
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public string Lang { get; set; } = null!;

    /// <summary>Stable machine key shared across languages (e.g. "ram", "screen").</summary>
    public string Key { get; set; } = null!;

    /// <summary>Localized label (e.g. "Оперативная память").</summary>
    public string Label { get; set; } = null!;

    /// <summary>Localized value (e.g. "16 ГБ").</summary>
    public string Value { get; set; } = null!;

    /// <summary>Ordering hint for display.</summary>
    public int SortOrder { get; set; }
}
