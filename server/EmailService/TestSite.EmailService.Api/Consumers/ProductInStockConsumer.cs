using MassTransit;
using TestSite.Contracts.Events.Email;
using TestSite.EmailService.Api.Abstractions;
using TestSite.EmailService.Domain.Abstractions;

namespace TestSite.EmailService.Api.Consumers
{
	public class ProductInStockConsumer : IConsumer<ProductInStockEvent>
	{
		private readonly ILogger<ProductInStockConsumer> _logger;
		private readonly IProductBackInStockAppService _productBackInStockAppService;

		public ProductInStockConsumer(IProductBackInStockAppService productBackInStockAppService, ILogger<ProductInStockConsumer> logger)
		{
			_productBackInStockAppService = productBackInStockAppService;
			_logger = logger;
		}

		public async Task Consume(ConsumeContext<ProductInStockEvent> context)
		{
			var emails = await _productBackInStockAppService.GetSubscribedEmails(context.Message.ProductId);

			Console.WriteLine("*********************");
			foreach (var email in emails)
			{
				Console.WriteLine($"Back in stock email sent: {email}");
			}
			Console.WriteLine("*********************");

			return;
		}
	}
}
