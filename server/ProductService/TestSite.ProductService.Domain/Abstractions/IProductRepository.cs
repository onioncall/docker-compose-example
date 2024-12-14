using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSite.ProductService.Domain.Entities;

namespace TestSite.ProductService.Domain.Abstractions;

public interface IProductRepository
{
	Task<Product> CreateProduct(Product product);

	Task<Product> GetProductById(int productId);

	Task UpdateProduct(Product product);
}