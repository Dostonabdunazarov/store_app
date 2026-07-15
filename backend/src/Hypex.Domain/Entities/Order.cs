using Hypex.Domain.Common;

namespace Hypex.Domain.Entities;

/// <summary>A customer order (pay on delivery). Stores contact + address snapshot.</summary>
public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    // Contact + delivery snapshot (captured at checkout time).
    public string ContactName { get; set; } = null!;
    public string ContactPhone { get; set; } = null!;
    public string ShippingCity { get; set; } = null!;
    public string ShippingAddress { get; set; } = null!;
    public string? Comment { get; set; }

    /// <summary>Sum of all line totals at creation time.</summary>
    public decimal TotalAmount { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
