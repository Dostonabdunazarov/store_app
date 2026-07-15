using Hypex.Application.Auth;
using Hypex.Application.Common;
using Hypex.Domain.Common;
using Hypex.Domain.Entities;
using Hypex.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hypex.Infrastructure.Auth;

public class AuthService(
    HypexDbContext db,
    IPasswordHasher hasher,
    ITokenService tokens) : IAuthService
{
    public async Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken ct = default)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        if (await db.Users.AnyAsync(u => u.Email == email, ct))
            throw AppException.Conflict("A user with this email already exists.");

        var user = new User
        {
            Email = email,
            FullName = request.FullName.Trim(),
            PasswordHash = hasher.Hash(request.Password),
            Role = UserRole.Customer,
        };

        db.Users.Add(user);
        await db.SaveChangesAsync(ct);

        return await IssueTokensAsync(user, ct);
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var email = request.Email.Trim().ToLowerInvariant();
        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == email, ct);

        if (user is null || !hasher.Verify(request.Password, user.PasswordHash))
            throw AppException.Unauthorized("Invalid email or password.");

        return await IssueTokensAsync(user, ct);
    }

    public async Task<AuthResponse> RefreshAsync(string refreshToken, CancellationToken ct = default)
    {
        var hash = tokens.HashRefreshToken(refreshToken);

        var stored = await db.RefreshTokens
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.TokenHash == hash, ct);

        if (stored is null || !stored.IsActive)
            throw AppException.Unauthorized("Invalid or expired refresh token.");

        // Rotate: revoke the used token and issue a fresh pair.
        stored.RevokedAt = DateTime.UtcNow;
        var response = await IssueTokensAsync(stored.User, ct);
        return response;
    }

    public async Task<UserDto?> GetByIdAsync(Guid userId, CancellationToken ct = default)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId, ct);
        return user is null ? null : ToDto(user);
    }

    private async Task<AuthResponse> IssueTokensAsync(User user, CancellationToken ct)
    {
        var (access, accessExp) = tokens.CreateAccessToken(user);
        var (rawRefresh, refreshHash, refreshExp) = tokens.CreateRefreshToken();

        db.RefreshTokens.Add(new RefreshToken
        {
            UserId = user.Id,
            TokenHash = refreshHash,
            ExpiresAt = refreshExp,
        });
        await db.SaveChangesAsync(ct);

        return new AuthResponse(access, rawRefresh, accessExp, ToDto(user));
    }

    private static UserDto ToDto(User u) => new(u.Id, u.Email, u.FullName, u.Role);
}
