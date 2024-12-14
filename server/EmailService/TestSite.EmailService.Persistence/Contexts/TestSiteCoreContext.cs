using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestSite.EmailService.Domain.Entities;

namespace TestSite.MemberService.Persistence.Contexts;

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

	public DbSet<ProductInStockEmailSubscriber> ProductInStockEmailSubscriber { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.HasDefaultSchema("email");
	}
}