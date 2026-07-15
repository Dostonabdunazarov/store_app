namespace Hypex.Domain.Entities;

/// <summary>A user's saved (favorited) product. Composite key (UserId, ProductId).</summary>
public class Favorite
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
