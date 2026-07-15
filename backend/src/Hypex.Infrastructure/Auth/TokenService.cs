using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Hypex.Application.Auth;
using Hypex.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Hypex.Infrastructure.Auth;

/// <summary>Creates JWT access tokens and opaque, hashed refresh tokens.</summary>
public class TokenService(IOptions<JwtOptions> options) : ITokenService
{
    private readonly JwtOptions _opts = options.Value;

    public (string token, DateTime expiresAt) CreateAccessToken(User user)
    {
        var expiresAt = DateTime.UtcNow.AddMinutes(_opts.AccessTokenMinutes);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.Role, user.Role.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_opts.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _opts.Issuer,
            Audience = _opts.Audience,
            Subject = new ClaimsIdentity(claims),
            Expires = expiresAt,
            SigningCredentials = creds,
        };

        var handler = new JsonWebTokenHandler();
        return (handler.CreateToken(descriptor), expiresAt);
    }

    public (string rawToken, string tokenHash, DateTime expiresAt) CreateRefreshToken()
    {
        var raw = Convert.ToBase64String(RandomNumberGenerator.GetBytes(48));
        var expiresAt = DateTime.UtcNow.AddDays(_opts.RefreshTokenDays);
        return (raw, HashRefreshToken(raw), expiresAt);
    }

    public string HashRefreshToken(string rawToken)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawToken));
        return Convert.ToBase64String(bytes);
    }
}
