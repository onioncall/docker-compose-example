using Microsoft.AspNetCore.Mvc;
using TestSite.Contracts.Requests;
using TestSite.EmailService.Api.Abstractions;

namespace TestSite.EmailService.Api.Controllers;

[ApiController]
[Route("api/email")]
public class ProductEmailController : ControllerBase
{
	private readonly ILogger<ProductEmailController> _logger;
	private readonly IProductBackInStockAppService _productBackInStockAppService;

	public ProductEmailController(IProductBackInStockAppService productBackInStockAppService, ILogger<ProductEmailController> logger)
	{
		_productBackInStockAppService = productBackInStockAppService;
		_logger = logger;
	}

	[HttpPost]
	[Route("create-back-in-stock-subscriber")]
	public async Task<IActionResult> CreateBackInStockSubscriber(CreateProductBackInStockSubscriberRequest request)
	{
		var subscriber = await _productBackInStockAppService.CreateSubscriber(request.ProductId, request.EmailAddress);

		if (subscriber == null)
		{
			return BadRequest();
		}

		return Ok(subscriber);
	}
}
