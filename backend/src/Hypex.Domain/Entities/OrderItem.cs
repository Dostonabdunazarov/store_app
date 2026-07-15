namespace Hypex.Domain.Entities;

/// <summary>
/// A line in an order. Captures a price/name snapshot so historical orders
/// remain accurate even if the product later changes or is removed.
/// </summary>
public class OrderItem
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    /// <summary>Reference to the product (nullable so orders survive product deletion).</summary>
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }

    // Snapshot at purchase time.
    public string ProductName { get; set; } = null!;
    public string? ProductImageUrl { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

    public decimal LineTotal => UnitPrice * Quantity;
}
