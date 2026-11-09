namespace Hypex.Infrastructure.Persistence.Seed;

public class SeedOptions
{
    public const string SectionName = "Seed";
    public const int MinAdminPasswordLength = 12;

    public string? AdminEmail { get; set; }
    public string? AdminPassword { get; set; }
    public bool RequireStrongAdminPassword { get; set; }
}
