using AutoMapper;
using TestSite.Contracts.Requests.Product;
using TestSite.Contracts.Models.Product;
using TestSite.ProductService.Domain.Args;
using TestSite.ProductService.Domain.Entities;

namespace TestSite.ProductService.Api;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<Product, ProductDto>().ReverseMap();
		CreateMap<ProductArgs, ProductCreateRequest>().ReverseMap();
	}
}
