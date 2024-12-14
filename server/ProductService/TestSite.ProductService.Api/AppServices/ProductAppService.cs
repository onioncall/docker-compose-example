using AutoMapper;
using MassTransit;
using TestSite.Contracts.Events;
using TestSite.ProductService.Api.Abstractions;
using TestSite.Contracts.Requests;
using TestSite.ProductService.Domain.Abstractions;
using TestSite.ProductService.Domain.Args;
using TestSite.ProductService.Domain.Entities;

namespace TestSite.ProductService.Api.AppServices;

public class ProductAppService : IProductAppService
{
	private readonly IMapper _mapper;

	private readonly IProductRepository _productRepository;

	private readonly IPublishEndpoint _publishEndpoint;

	public ProductAppService(IMapper mapper, IProductRepository productRepository, IPublishEndpoint publishEndpoint)
	{
		_mapper = mapper;
		_productRepository = productRepository;
		_publishEndpoint = publishEndpoint;
	}

	public async Task<Product?> CreateProduct(ProductCreateRequest request)
	{
		var args = _mapper.Map<ProductArgs>(request);

		var product = new Product(args);

		var result = await _productRepository.CreateProduct(product);

		return product;
	}

	public async Task<Product?> GetProductById(int productId)
	{
		var product = await _productRepository.GetProductById(productId);

		return product;
	}

	public async Task<Product?> UpdateProductQuantity(int productId, int quantity)
	{
		var product = await _productRepository.GetProductById(productId);
		var inStock = product.Quantity > 0 ? true : false;

		if (product != null)
		{
			product.UpdateQuantity(quantity);
			await _productRepository.UpdateProduct(product);

			if (!inStock && quantity > 1)
			{
				var productInStockEvent = new ProductInStockEvent() { ProductId = productId };

				await _publishEndpoint.Publish(productInStockEvent);
			}
		}

		return product;
	}
}