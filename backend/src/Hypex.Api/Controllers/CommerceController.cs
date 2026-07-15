using System.Security.Claims;
using Hypex.Application.Commerce;
using Hypex.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Hypex.Api.Controllers;

[ApiController, Authorize]
[Route("api/favorites")]
public class FavoritesController(ICommerceService service) : ControllerBase
{
    [HttpGet] public async Task<IActionResult> Get(CancellationToken ct) => Ok(await service.GetFavoritesAsync(UserId(), ct));
    [HttpPost("{productId:guid}")] public async Task<IActionResult> Add(Guid productId, CancellationToken ct) { await service.AddFavoriteAsync(UserId(), productId, ct); return NoContent(); }
    [HttpDelete("{productId:guid}")] public async Task<IActionResult> Remove(Guid productId, CancellationToken ct) { await service.RemoveFavoriteAsync(UserId(), productId, ct); return NoContent(); }
    private Guid UserId() => ClaimsPrincipalExtensions.GetUserId(User);
}

[ApiController]
[Route("api/products/{productId:guid}/reviews")]
public class ReviewsController(ICommerceService service) : ControllerBase
{
    [HttpGet] public async Task<IActionResult> Get(Guid productId, CancellationToken ct) => Ok(await service.GetReviewsAsync(productId, ct));
    [Authorize, HttpPost] public async Task<IActionResult> Add(Guid productId, CreateReviewRequest request, CancellationToken ct) => Ok(await service.AddReviewAsync(ClaimsPrincipalExtensions.GetUserId(User), productId, request, ct));
}

[ApiController, Authorize]
[Route("api/orders")]
public class OrdersController(ICommerceService service) : ControllerBase
{
    [HttpPost] public async Task<IActionResult> Create(CreateOrderRequest request, CancellationToken ct) => Created("", await service.CreateOrderAsync(ClaimsPrincipalExtensions.GetUserId(User), request, ct));
    [HttpGet] public async Task<IActionResult> Get(CancellationToken ct) => Ok(await service.GetOrdersAsync(ClaimsPrincipalExtensions.GetUserId(User), ct));
    [HttpGet("{id:guid}")] public async Task<IActionResult> GetOne(Guid id, CancellationToken ct) => Ok(await service.GetOrderAsync(ClaimsPrincipalExtensions.GetUserId(User), id, false, ct) ?? throw AppException.NotFound("Order not found."));
}

internal static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(ClaimsPrincipal user)
    {
        var value = user.FindFirstValue(JwtRegisteredClaimNames.Sub) ?? user.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(value, out var id) ? id : throw AppException.Unauthorized("Invalid token subject.");
    }
}
