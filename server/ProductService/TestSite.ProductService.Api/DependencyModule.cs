using TestSite.ProductService.Api.Abstractions;
using TestSite.ProductService.Api.AppServices;
using TestSite.ProductService.Domain.Abstractions;
using TestSite.ProductService.Persistence.Repositories;

namespace TestSite.ProductService.Api;

public class DependencyModule
{
	public void RegisterDependencies(IServiceCollection services)
	{
		services.AddScoped<IProductAppService, ProductAppService>();
		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddAutoMapper(typeof(AutoMapperProfile));
	}
}