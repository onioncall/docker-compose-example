using MassTransit;
using TestSite.EmailService.Api.Consumers;

namespace TestSite.EmailService.Api;

public class DependencyModule
{
	public void RegisterDependencies(IServiceCollection services)
	{
		// Implement
	}

	public void RegisterMessagingConsumers(IBusRegistrationContext ctx, IRabbitMqBusFactoryConfigurator cfg)
	{
		cfg.ReceiveEndpoint("product_in_stock", ec =>
		{
			ec.Consumer<ProductInStockConsumer>(ctx);
		});
	}
}