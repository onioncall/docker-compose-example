using TestSite.Contracts.Requests.Product;
using TestSite.ProductService.Domain.Entities;

namespace TestSite.ProductService.Api.Abstractions;

public interface IProductAppService
{
	Task<Product?> CreateProduct(ProductCreateRequest request);

	Task<Product?> GetProductById(int productId);

	Task<Product?> UpdateProductQuantity(int productId, int quantity);
}
