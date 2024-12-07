using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestSite.AuthService.Domain.Entities;

namespace TestSite.AuthService.Persistence.Contexts;

public class TestSiteCoreContext : DbContext
{
	private readonly ILogger<TestSiteCoreContext> _logger;

	public TestSiteCoreContext(DbContextOptions dbContextOptions, ILogger<TestSiteCoreContext> logger) : base(dbContextOptions)
	{
		_logger = logger;

		if (!Database.CanConnect())
		{
			_logger.LogError("failed to connect TestSiteCore");
		}
	}

	public DbSet<Member> Member { get; set; }

	public DbSet<MemberCredentials> MemberCredentials { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.HasDefaultSchema("auth");

		modelBuilder
			.Entity<Member>()
			.HasOne(m => m.MemberCredentials)
			.WithOne(mc => mc.Member)
			.HasForeignKey<MemberCredentials>(mc => mc.MemberId)
			.IsRequired(false);

		modelBuilder
			.Entity<Member>()
			.Property(m => m.Department)
			.HasConversion<int>()
			.HasColumnName("department_id");
	}
}
