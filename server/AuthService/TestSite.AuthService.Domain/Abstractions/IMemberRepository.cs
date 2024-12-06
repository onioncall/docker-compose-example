using TestSite.AuthService.Domain.Entities;

namespace TestSite.AuthService.Domain.Abstractions;

public interface IMemberRepository
{
	Task<Member> AddMember(Member member);

	Task AddMemberCredentials(int memberId, string password);

	Task<Member> GetByIdAsync(int memberId);

	Task UpdateMemberCredentials(int memberId, string password);
}