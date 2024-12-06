using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestSite.AuthService.Persistence.Contexts;
using TestSite.AuthService.Domain.Abstractions;
using TestSite.AuthService.Domain.Entities;

namespace TestSite.AuthService.Persistence.Repositories;

public class MemberRepository : IMemberRepository
{
	private readonly TestSiteCoreContext _dbContext;

	private readonly ILogger<MemberRepository> _logger;

	public MemberRepository(TestSiteCoreContext dbContext, ILogger<MemberRepository> logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<Member> AddMember(Member member)
	{
		try
		{
			await _dbContext.Member.AddAsync(member);
			await _dbContext.SaveChangesAsync();

			return member;
		}
		catch (Exception ex)
		{
			var message = $"error adding member: {member.EmailAddress}";
			_logger.LogError(message, ex);
			throw new Exception(message);
		}
	}

	public async Task AddMemberCredentials(int memberId, string password)
	{
		try
		{
			var member = await _dbContext.Member.FirstAsync(m => m.MemberId == memberId);
			member.AddCredentials(password);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			var message = $"error adding member credentials for id: {memberId}";
			_logger.LogError(message, ex);
			throw new Exception(message);
		}
	}

	public async Task<Member> GetByIdAsync(int memberId)
	{
		try
		{
			var member = await _dbContext.Member.FirstAsync(m => m.MemberId == memberId);
			return member;
		}
		catch (Exception ex)
		{
			var message = $"error getting product base by id: {memberId}";
			_logger.LogError(message, ex);
			throw new Exception(message);
		}
	}

	public async Task UpdateMemberCredentials(int memberId, string password)
	{
		try
		{
			var member = await _dbContext.Member.FirstAsync(m => m.MemberId == memberId);
			member.UpdateCredentials(password);
			await _dbContext.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			var message = $"error updating member credentials for id: {memberId}";
			_logger.LogError(message, ex);
			throw new Exception(message);
		}
	}
}