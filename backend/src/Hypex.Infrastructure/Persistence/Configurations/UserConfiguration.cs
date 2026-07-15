using Hypex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hypex.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> b)
    {
        b.ToTable("users");
        b.HasKey(u => u.Id);

        b.Property(u => u.Email).HasMaxLength(256).IsRequired();
        b.HasIndex(u => u.Email).IsUnique();

        b.Property(u => u.PasswordHash).IsRequired();
        b.Property(u => u.FullName).HasMaxLength(200).IsRequired();
        b.Property(u => u.Role).HasConversion<string>().HasMaxLength(32);

        b.HasMany(u => u.RefreshTokens)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> b)
    {
        b.ToTable("refresh_tokens");
        b.HasKey(t => t.Id);

        b.Property(t => t.TokenHash).HasMaxLength(256).IsRequired();
        b.HasIndex(t => t.TokenHash);
        b.Ignore(t => t.IsActive);
    }
}
