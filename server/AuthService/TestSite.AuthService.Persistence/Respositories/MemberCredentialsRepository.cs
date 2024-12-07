using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestSite.AuthService.Persistence.Contexts;
using TestSite.AuthService.Domain.Entities;
using TestSite.AuthService.Domain.Abstractions;

namespace TestSite.AuthService.Persistence.Repositories;

public class MemberCredentialsRepository : IMemberCredentialsRepository
{
	private readonly TestSiteCoreContext _dbContext;

	private readonly ILogger<MemberCredentialsRepository> _logger;

	public MemberCredentialsRepository(TestSiteCoreContext dbContext, ILogger<MemberCredentialsRepository> logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<MemberCredentials> GetCredentials(string username)
	{
		// checking email if username isn't found
		var memberCredentials = await _dbContext.MemberCredentials
			.Include(mc => mc.Member)
			.FirstAsync(mc => mc.Member.Username == username || mc.Member.EmailAddress == username);

		return memberCredentials;
	}
}
