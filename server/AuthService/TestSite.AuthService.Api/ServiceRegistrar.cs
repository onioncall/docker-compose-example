using TestSite.AuthService.Api.Abstractions;
using TestSite.AuthService.Api.AppServices;
using TestSite.AuthService.Domain.Abstractions;
using TestSite.AuthService.Persistence.Repositories;

namespace TestSite.AuthService.Api;

public class ServiceRegistrar
{
	public void RegisterServices(IServiceCollection services)
	{
		services.AddScoped<IAuthAppService, AuthAppService>();
		services.AddScoped<IMemberRepository, MemberRepository>();
		services.AddScoped<IMemberCredentialsRepository, MemberCredentialsRepository>();
		services.AddScoped<ITokenAppService, TokenAppService>();
		services.AddAutoMapper(typeof(AutoMapperProfile));
	}
}
