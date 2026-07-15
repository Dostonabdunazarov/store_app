using Hypex.Application.Commerce;
using Hypex.Application.Common;
using Hypex.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hypex.Api.Controllers;

[ApiController, Authorize(Roles = "Admin")]
[Route("api/admin")]
public class AdminController(ICommerceService service) : ControllerBase
{
    [HttpGet("orders")] public async Task<IActionResult> Orders(CancellationToken ct) => Ok(await service.GetAllOrdersAsync(ct));
    [HttpPatch("orders/{id:guid}/status")] public async Task<IActionResult> Status(Guid id, UpdateOrderStatusRequest request, CancellationToken ct) { await service.UpdateOrderStatusAsync(id, request.Status, ct); return NoContent(); }
    [HttpGet("products")] public async Task<IActionResult> Products(CancellationToken ct) => Ok(await service.GetAdminProductsAsync(ct));
    [HttpGet("products/{id:guid}")] public async Task<IActionResult> Product(Guid id, CancellationToken ct) => Ok(await service.GetAdminProductAsync(id, ct) ?? throw AppException.NotFound("Product not found."));
    [HttpPost("products")] public async Task<IActionResult> CreateProduct(ProductUpsertRequest request, CancellationToken ct) => Ok(await service.CreateProductAsync(request, ct));
    [HttpPut("products/{id:guid}")] public async Task<IActionResult> UpdateProduct(Guid id, ProductUpsertRequest request, CancellationToken ct) => Ok(await service.UpdateProductAsync(id, request, ct) ?? throw AppException.NotFound("Product not found."));
    [HttpDelete("products/{id:guid}")] public async Task<IActionResult> DeleteProduct(Guid id, CancellationToken ct) { await service.DeleteProductAsync(id, ct); return NoContent(); }
    [HttpPost("categories")] public async Task<IActionResult> CreateCategory(CategoryUpsertRequest request, CancellationToken ct) => Ok(await service.CreateCategoryAsync(request, ct));
    [HttpPost("brands")] public async Task<IActionResult> CreateBrand(BrandUpsertRequest request, CancellationToken ct) => Ok(await service.CreateBrandAsync(request, ct));
    [HttpPut("categories/{id:int}")] public async Task<IActionResult> UpdateCategory(int id, CategoryUpsertRequest request, CancellationToken ct) => Ok(await service.UpdateCategoryAsync(id, request, ct) ?? throw AppException.NotFound("Category not found."));
    [HttpDelete("categories/{id:int}")] public async Task<IActionResult> DeleteCategory(int id, CancellationToken ct) { await service.DeleteCategoryAsync(id, ct); return NoContent(); }
    [HttpPut("brands/{id:int}")] public async Task<IActionResult> UpdateBrand(int id, BrandUpsertRequest request, CancellationToken ct) => Ok(await service.UpdateBrandAsync(id, request, ct) ?? throw AppException.NotFound("Brand not found."));
    [HttpDelete("brands/{id:int}")] public async Task<IActionResult> DeleteBrand(int id, CancellationToken ct) { await service.DeleteBrandAsync(id, ct); return NoContent(); }
    [HttpGet("orders/{id:guid}")] public async Task<IActionResult> Order(Guid id, CancellationToken ct) => Ok(await service.GetOrderAsync(Guid.Empty, id, true, ct) ?? throw AppException.NotFound("Order not found."));
}
