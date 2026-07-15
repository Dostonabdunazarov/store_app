using Hypex.Domain.Common;

namespace Hypex.Application.Auth;

public record RegisterRequest(string Email, string Password, string FullName);

public record LoginRequest(string Email, string Password);

public record RefreshRequest(string RefreshToken);

/// <summary>Auth result returned to the client after register/login/refresh.</summary>
public record AuthResponse(
    string AccessToken,
    string RefreshToken,
    DateTime AccessTokenExpiresAt,
    UserDto User);

public record UserDto(Guid Id, string Email, string FullName, UserRole Role);
