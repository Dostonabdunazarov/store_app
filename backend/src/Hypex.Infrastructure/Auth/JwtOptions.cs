namespace Hypex.Infrastructure.Auth;

/// <summary>Bound from the "Jwt" configuration section.</summary>
public class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Issuer { get; set; } = "Hypex";
    public string Audience { get; set; } = "HypexClient";
    public string Key { get; set; } = null!;
    public int AccessTokenMinutes { get; set; } = 15;
    public int RefreshTokenDays { get; set; } = 7;
}
