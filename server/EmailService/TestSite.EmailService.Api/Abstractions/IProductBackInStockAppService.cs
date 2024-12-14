using TestSite.EmailService.Domain.Entities;

namespace TestSite.EmailService.Api.Abstractions;

public interface IProductBackInStockAppService
{
	Task<ProductInStockEmailSubscriber> CreateSubscriber(int productId, string emailAddress);

	Task<List<string>> GetSubscribedEmails(int productId);
}