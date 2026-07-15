using Hypex.Application.Auth;
using Hypex.Domain.Common;
using Hypex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hypex.Infrastructure.Persistence.Seed;

/// <summary>
/// Idempotently applies pending migrations and seeds reference data:
/// an admin user, categories, brands, and the demo product catalog (RU/UZ/EN).
/// Safe to run on every startup — each step no-ops if its data already exists.
/// </summary>
public class DataSeeder(
    HypexDbContext db,
    IPasswordHasher hasher,
    ILogger<DataSeeder> logger)
{
    public async Task SeedAsync(CancellationToken ct = default)
    {
        await db.Database.MigrateAsync(ct);

        await SeedAdminAsync(ct);
        await SeedCategoriesAsync(ct);
        await SeedBrandsAsync(ct);
        await SeedProductsAsync(ct);
        await SyncProductImagesAsync(ct);
        await SyncIdentitySequencesAsync(ct);
    }

    /// <summary>
    /// Realign each seeded product's <see cref="Product.ImageUrls"/> to the current
    /// seed catalog (matched by slug). Lets image-only updates in the seed take effect
    /// on an already-populated database without a full re-seed. Idempotent: only
    /// products whose images differ are touched; orders/reviews are untouched.
    /// </summary>
    private async Task SyncProductImagesAsync(CancellationToken ct)
    {
        var bySlug = SeedCatalog.Products.ToDictionary(p => p.Slug, p => p.ImageUrls);
        var products = await db.Products.ToListAsync(ct);

        var updated = 0;
        foreach (var product in products)
        {
            if (!bySlug.TryGetValue(product.Slug, out var images))
                continue;
            if (product.ImageUrls.SequenceEqual(images))
                continue;

            product.ImageUrls = images.ToList();
            updated++;
        }

        if (updated > 0)
        {
            await db.SaveChangesAsync(ct);
            logger.LogInformation("Synced images for {Count} products", updated);
        }
    }

    /// <summary>
    /// The category/brand seed inserts explicit int Ids, which does not advance the
    /// Postgres identity sequence. Realign each sequence to MAX(id) so later
    /// EF-generated inserts (admin CRUD) don't collide with seeded rows.
    /// Idempotent and safe to run on every startup.
    /// </summary>
    private async Task SyncIdentitySequencesAsync(CancellationToken ct)
    {
        await db.Database.ExecuteSqlRawAsync(
            "SELECT setval(pg_get_serial_sequence('categories', 'Id'), GREATEST((SELECT MAX(\"Id\") FROM categories), 1)); " +
            "SELECT setval(pg_get_serial_sequence('brands', 'Id'), GREATEST((SELECT MAX(\"Id\") FROM brands), 1));",
            ct);
    }

    private async Task SeedAdminAsync(CancellationToken ct)
    {
        const string adminEmail = "admin@hypex.local";
        if (await db.Users.AnyAsync(u => u.Email == adminEmail, ct))
            return;

        db.Users.Add(new User
        {
            Email = adminEmail,
            FullName = "Hypex Admin",
            PasswordHash = hasher.Hash("Admin123!"),
            Role = UserRole.Admin,
        });
        await db.SaveChangesAsync(ct);
        logger.LogInformation("Seeded admin user {Email}", adminEmail);
    }

    private async Task SeedCategoriesAsync(CancellationToken ct)
    {
        if (await db.Categories.AnyAsync(ct))
            return;

        foreach (var c in SeedCatalog.Categories)
        {
            var category = new Category { Id = c.Id, Slug = c.Slug };
            foreach (var lang in Languages.All)
            {
                category.Translations.Add(new CategoryTranslation
                {
                    Lang = lang,
                    Name = c.Name.For(lang),
                });
            }
            db.Categories.Add(category);
        }
        await db.SaveChangesAsync(ct);
        logger.LogInformation("Seeded {Count} categories", SeedCatalog.Categories.Count);
    }

    private async Task SeedBrandsAsync(CancellationToken ct)
    {
        if (await db.Brands.AnyAsync(ct))
            return;

        foreach (var b in SeedCatalog.Brands)
            db.Brands.Add(new Brand { Id = b.Id, Slug = b.Slug, Name = b.Name });

        await db.SaveChangesAsync(ct);
        logger.LogInformation("Seeded {Count} brands", SeedCatalog.Brands.Count);
    }

    private async Task SeedProductsAsync(CancellationToken ct)
    {
        if (await db.Products.AnyAsync(ct))
            return;

        foreach (var p in SeedCatalog.Products)
        {
            var product = new Product
            {
                Slug = p.Slug,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                Price = p.Price,
                Stock = p.Stock,
                ImageUrls = p.ImageUrls.ToList(),
                RatingAverage = p.RatingAverage,
                RatingCount = p.RatingCount,
                IsActive = true,
            };

            foreach (var lang in Languages.All)
            {
                product.Translations.Add(new ProductTranslation
                {
                    Lang = lang,
                    Name = p.Name.For(lang),
                    Description = p.Description.For(lang),
                });

                var order = 0;
                foreach (var a in p.Attributes)
                {
                    product.Attributes.Add(new ProductAttribute
                    {
                        Lang = lang,
                        Key = a.Key,
                        Label = a.Label.For(lang),
                        Value = a.Value.For(lang),
                        SortOrder = order++,
                    });
                }
            }

            db.Products.Add(product);
        }

        await db.SaveChangesAsync(ct);
        logger.LogInformation("Seeded {Count} products", SeedCatalog.Products.Count);
    }
}
