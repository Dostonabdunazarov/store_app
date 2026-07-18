using Hypex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hypex.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> b)
    {
        b.ToTable("categories");
        b.HasKey(c => c.Id);
        b.Property(c => c.Slug).HasMaxLength(120).IsRequired();
        b.HasIndex(c => c.Slug).IsUnique();

        b.HasMany(c => c.Translations)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
{
    public void Configure(EntityTypeBuilder<CategoryTranslation> b)
    {
        b.ToTable("category_translations");
        b.HasKey(t => t.Id);
        b.Property(t => t.Lang).HasMaxLength(5).IsRequired();
        b.Property(t => t.Name).HasMaxLength(160).IsRequired();
        b.HasIndex(t => new { t.CategoryId, t.Lang }).IsUnique();
    }
}

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> b)
    {
        b.ToTable("brands");
        b.HasKey(x => x.Id);
        b.Property(x => x.Slug).HasMaxLength(120).IsRequired();
        b.HasIndex(x => x.Slug).IsUnique();
        b.Property(x => x.Name).HasMaxLength(120).IsRequired();
        b.Property(x => x.LogoUrl).HasMaxLength(512);
    }
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> b)
    {
        b.ToTable("products");
        b.HasKey(p => p.Id);

        b.Property(p => p.Slug).HasMaxLength(160).IsRequired();
        b.HasIndex(p => p.Slug).IsUnique();

        b.Property(p => p.Price).HasColumnType("numeric(12,2)");
        b.Property(p => p.OldPrice).HasColumnType("numeric(12,2)");
        b.Property(p => p.ImageUrls)
            .HasColumnType("jsonb");

        b.HasIndex(p => p.CategoryId);
        b.HasIndex(p => p.BrandId);
        b.HasIndex(p => p.IsActive);

        b.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(p => p.Brand)
            .WithMany(br => br.Products)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasMany(p => p.Translations)
            .WithOne(t => t.Product)
            .HasForeignKey(t => t.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasMany(p => p.Attributes)
            .WithOne(a => a.Product)
            .HasForeignKey(a => a.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
{
    public void Configure(EntityTypeBuilder<ProductTranslation> b)
    {
        b.ToTable("product_translations");
        b.HasKey(t => t.Id);
        b.Property(t => t.Lang).HasMaxLength(5).IsRequired();
        b.Property(t => t.Name).HasMaxLength(250).IsRequired();
        b.Property(t => t.Description).IsRequired();
        b.HasIndex(t => new { t.ProductId, t.Lang }).IsUnique();
    }
}

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> b)
    {
        b.ToTable("product_attributes");
        b.HasKey(a => a.Id);
        b.Property(a => a.Lang).HasMaxLength(5).IsRequired();
        b.Property(a => a.Key).HasMaxLength(60).IsRequired();
        b.Property(a => a.Label).HasMaxLength(120).IsRequired();
        b.Property(a => a.Value).HasMaxLength(250).IsRequired();
        b.HasIndex(a => new { a.ProductId, a.Lang, a.Key }).IsUnique();
    }
}
