using Hypex.Domain.Entities;

namespace Hypex.Application.Auth;

/// <summary>Issues JWT access tokens and opaque refresh tokens.</summary>
public interface ITokenService
{
    (string token, DateTime expiresAt) CreateAccessToken(User user);

    /// <summary>Creates a raw refresh token plus its storage hash and expiry.</summary>
    (string rawToken, string tokenHash, DateTime expiresAt) CreateRefreshToken();

    /// <summary>Hashes a raw refresh token for lookup/comparison.</summary>
    string HashRefreshToken(string rawToken);
}
