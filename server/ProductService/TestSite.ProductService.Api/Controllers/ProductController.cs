using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSite.Contracts.Requests.Product;
using TestSite.ProductService.Api.Abstractions;

namespace TestSite.ProductService.Api.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly ILogger _logger;

	private readonly IProductAppService _productAppService;

	public ProductController(IProductAppService productAppService)
	{
		_productAppService = productAppService;
	}

	[HttpPost]
	[Route("create-product")]
	public async Task<IActionResult> CreateProduct(ProductCreateRequest request)
	{
		var product = await _productAppService.CreateProduct(request);

		if (product == null)
		{
			return BadRequest();
		}

		return Ok(product);
	}

	[HttpGet]
	public async Task<IActionResult> GetProductById([FromQuery] int productId)
	{
		var product = await _productAppService.GetProductById(productId);

		if (product == null)
		{
			return NotFound();
		}

		return Ok(product);
	}

	[HttpPut]
	[Route("update-product-quantity")]
	public async Task<IActionResult> UpdateProductQuantity(ProductUpdateQuantityRequest request)
	{
		var product = await _productAppService.UpdateProductQuantity(request.ProductId, request.Quantity);

		if (product == null)
		{
			return NotFound();
		}

		return Ok(product);
	}
}
