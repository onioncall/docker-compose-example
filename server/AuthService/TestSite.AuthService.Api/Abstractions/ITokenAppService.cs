using TestSite.AuthService.Domain.Entities;

namespace TestSite.AuthService.Api.Abstractions;

public interface ITokenAppService
{
	public string GenerateJwtToken(int memberId, DepartmentType department);
}
