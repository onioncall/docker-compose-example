using MassTransit;
using TestSite.Contracts.Events;

namespace TestSite.EmailService.Api.Consumers
{
	public class ProductInStockConsumer : IConsumer<ProductInStockEvent>
	{
		public Task Consume(ConsumeContext<ProductInStockEvent> context)
		{
			throw new NotImplementedException();
		}
	}
}