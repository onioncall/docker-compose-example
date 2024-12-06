using TestSite.AuthService.Domain.Entities;

namespace TestSite.AuthService.Domain.Abstractions;

public interface IMemberCredentialsRepository
{
	Task<MemberCredentials> GetCredentials(string username);
}