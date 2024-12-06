using TestSite.AuthService.Contract.Models;
using TestSite.AuthService.Contract.Requests;

namespace TestSite.AuthService.Api.Abstractions;

public interface IAuthAppService
{
	Task<MemberDto> AddMember(AddMemberRequest request);

	Task AddMemberCredentials(int memberId, string password);

	Task<MemberDto> GetMemberById(int id);

	Task<bool> LoginMember(string username, string password);

	Task UpdateMemberCredentials(int memberId, string password);
}