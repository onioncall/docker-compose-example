using TestSite.EmailService.Api.Abstractions;
using TestSite.EmailService.Domain.Abstractions;
using TestSite.EmailService.Domain.Entities;

namespace TestSite.EmailService.Api.AppServices;

public class ProductBackInStockAppService : IProductBackInStockAppService
{
	private readonly IEmailRepository _emailRepository;

	public ProductBackInStockAppService(IEmailRepository emailRepository)
	{
		_emailRepository = emailRepository;
	}

	public async Task<ProductInStockEmailSubscriber> CreateSubscriber(int productId, string emailAddress)
	{
		var subscriber = new ProductInStockEmailSubscriber(productId, emailAddress);
		var result = await _emailRepository.CreateProductInStockEmailSubscriber(subscriber);

		return result;
	}

	public async Task<List<string>> GetSubscribedEmails(int productId)
	{
		var emails = await _emailRepository.GetProductInStockEmailSubscribers(productId);

		return emails;
	}
}