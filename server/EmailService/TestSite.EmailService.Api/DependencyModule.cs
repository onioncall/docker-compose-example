using MassTransit;
using TestSite.EmailService.Api.Abstractions;
using TestSite.EmailService.Api.AppServices;
using TestSite.EmailService.Api.Consumers;
using TestSite.EmailService.Domain.Abstractions;
using TestSite.EmailService.Persistence.Repositories;

namespace TestSite.EmailService.Api;

public class DependencyModule
{
	public void RegisterDependencies(IServiceCollection services)
	{
		services.AddScoped<IProductBackInStockAppService, ProductBackInStockAppService>();
		services.AddScoped<IEmailRepository, EmailRepository>();
	}

	public void RegisterMessagingConsumers(IBusRegistrationContext ctx, IRabbitMqBusFactoryConfigurator cfg)
	{
		cfg.ReceiveEndpoint("product_in_stock", ec =>
		{
			ec.Consumer<ProductInStockConsumer>(ctx);
		});
	}
}