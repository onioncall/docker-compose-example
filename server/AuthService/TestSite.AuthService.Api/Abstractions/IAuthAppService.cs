using TestSite.Contract.Requests.Auth;
using TestSite.Contract.Models.Auth;

namespace TestSite.AuthService.Api.Abstractions;

public interface IAuthAppService
{
	Task<MemberDto> AddMember(AddMemberRequest request);

	Task AddMemberCredentials(int memberId, string password);

	Task<MemberDto> GetMemberById(int id);

	Task<string> LoginMember(string username, string password);

	Task UpdateMemberCredentials(int memberId, string password);
}
