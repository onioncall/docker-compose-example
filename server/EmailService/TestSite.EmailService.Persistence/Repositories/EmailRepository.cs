using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSite.EmailService.Domain.Abstractions;
using TestSite.EmailService.Domain.Entities;
using TestSite.MemberService.Persistence.Contexts;

namespace TestSite.EmailService.Persistence.Repositories;

public class EmailRepository : IEmailRepository
{
	private readonly TestSiteCoreContext _dbContext;

	private readonly ILogger<EmailRepository> _logger;

	public EmailRepository(TestSiteCoreContext dbContext, ILogger<EmailRepository> logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<ProductInStockEmailSubscriber> CreateProductInStockEmailSubscriber(ProductInStockEmailSubscriber subscriber)
	{
		try
		{
			var entry = await _dbContext.ProductInStockEmailSubscriber.AddAsync(subscriber);
			await _dbContext.SaveChangesAsync();

			return entry.Entity;
		}
		catch (Exception ex)
		{
			var message = $"error adding product: {subscriber.ProductId}";
			_logger.LogError(message, ex);
			throw new Exception(message);
		}
	}

	public async Task<List<string>> GetProductInStockEmailSubscribers(int productId)
	{
		try
		{
			var subscribers = await _dbContext.ProductInStockEmailSubscriber
				.Where(e => e.ProductId == productId && e.IsSent == false)
				.Select(e => e.EmailAddress)
				.ToListAsync();

			if (subscribers == null)
			{
				throw new NullReferenceException();
			}

			return subscribers;
		}
		catch (Exception ex)
		{
			var message = $"error getting subscribers by id: {productId}";
			_logger.LogError(message, ex);
			throw new Exception(message);
		}
	}
}