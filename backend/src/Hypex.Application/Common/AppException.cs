namespace Hypex.Application.Common;

/// <summary>
/// An expected, client-facing error carrying an HTTP status code.
/// Translated to a ProblemDetails response by the API's exception handler.
/// </summary>
public class AppException(int statusCode, string message) : Exception(message)
{
    public int StatusCode { get; } = statusCode;

    public static AppException NotFound(string message) => new(404, message);
    public static AppException BadRequest(string message) => new(400, message);
    public static AppException Unauthorized(string message) => new(401, message);
    public static AppException Conflict(string message) => new(409, message);
}
