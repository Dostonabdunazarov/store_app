using Hypex.Application.Catalog;
using Hypex.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace Hypex.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(ICatalogService catalog) : ControllerBase
{
    /// <summary>Paged, filterable, sortable, searchable product listing.</summary>
    [HttpGet]
    public async Task<ActionResult<PagedResult<ProductListItemDto>>> Get(
        [FromQuery] ProductQuery query, CancellationToken ct)
        => Ok(await catalog.GetProductsAsync(query, ct));

    [HttpGet("{slug}")]
    public async Task<ActionResult<ProductDetailDto>> GetBySlug(string slug, CancellationToken ct)
    {
        var product = await catalog.GetProductBySlugAsync(slug, ct)
            ?? throw AppException.NotFound($"Product '{slug}' not found.");
        return Ok(product);
    }
}

[ApiController]
[Route("api/categories")]
public class CategoriesController(ICatalogService catalog) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CategoryDto>>> Get(CancellationToken ct)
        => Ok(await catalog.GetCategoriesAsync(ct));
}

[ApiController]
[Route("api/brands")]
public class BrandsController(ICatalogService catalog) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<BrandDto>>> Get(CancellationToken ct)
        => Ok(await catalog.GetBrandsAsync(ct));
}

