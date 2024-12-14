using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSite.MemberService.Persistence.Contexts;
using TestSite.ProductService.Domain.Abstractions;
using TestSite.ProductService.Domain.Entities;

namespace TestSite.ProductService.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
	private readonly TestSiteCoreContext _dbContext;

	private readonly ILogger<ProductRepository> _logger;

	public ProductRepository(TestSiteCoreContext dbContext, ILogger<ProductRepository> logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<Product> CreateProduct(Product product)
	{
		try
		{
			var entry = await _dbContext.Product.AddAsync(product);
			await _dbContext.SaveChangesAsync();

			return entry.Entity;
		}
		catch (Exception ex)
		{
			var message = $"error adding product: {product.ItemNumber}";
			_logger.LogError(message, ex);
			throw new Exception(message);
		}
	}

	public async Task<Product> GetProductById(int productId)
	{
		try
		{
			var product = await _dbContext.Product.FindAsync(productId);

			if (product == null)
			{
				throw new NullReferenceException();
			}

			return product;
		}
		catch (Exception ex)
		{
			var message = $"error getting product by id: {productId}";
			_logger.LogError(message, ex);
			throw new Exception(message);
		}
	}

	public async Task UpdateProduct(Product product)
	{
		try
		{
			var result = _dbContext.Product.Update(product);

			await _dbContext.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			var message = $"error getting updating product: {product.ProductId}";
			_logger.LogError(message, ex);
			throw new Exception(message);
		}
	}
}