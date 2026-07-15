using Hypex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hypex.Infrastructure.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> b)
    {
        b.ToTable("reviews");
        b.HasKey(r => r.Id);
        b.Property(r => r.Comment).HasMaxLength(2000);

        b.HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One review per user per product.
        b.HasIndex(r => new { r.ProductId, r.UserId }).IsUnique();
    }
}

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> b)
    {
        b.ToTable("favorites");
        b.HasKey(f => new { f.UserId, f.ProductId });

        b.HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(f => f.Product)
            .WithMany(p => p.Favorites)
            .HasForeignKey(f => f.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> b)
    {
        b.ToTable("orders");
        b.HasKey(o => o.Id);

        b.Property(o => o.Status).HasConversion<string>().HasMaxLength(32);
        b.Property(o => o.ContactName).HasMaxLength(200).IsRequired();
        b.Property(o => o.ContactPhone).HasMaxLength(40).IsRequired();
        b.Property(o => o.ShippingCity).HasMaxLength(120).IsRequired();
        b.Property(o => o.ShippingAddress).HasMaxLength(500).IsRequired();
        b.Property(o => o.Comment).HasMaxLength(1000);
        b.Property(o => o.TotalAmount).HasColumnType("numeric(12,2)");

        b.HasIndex(o => o.UserId);
        b.HasIndex(o => o.Status);

        b.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasMany(o => o.Items)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> b)
    {
        b.ToTable("order_items");
        b.HasKey(i => i.Id);

        b.Property(i => i.ProductName).HasMaxLength(250).IsRequired();
        b.Property(i => i.ProductImageUrl).HasMaxLength(512);
        b.Property(i => i.UnitPrice).HasColumnType("numeric(12,2)");
        b.Ignore(i => i.LineTotal);

        // Keep line snapshot even if the product row is deleted.
        b.HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
