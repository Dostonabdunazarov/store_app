namespace Hypex.Application.Auth;

/// <summary>Registration, login and refresh-token rotation.</summary>
public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken ct = default);
    Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken ct = default);
    Task<AuthResponse> RefreshAsync(string refreshToken, CancellationToken ct = default);
    Task<UserDto?> GetByIdAsync(Guid userId, CancellationToken ct = default);
}
