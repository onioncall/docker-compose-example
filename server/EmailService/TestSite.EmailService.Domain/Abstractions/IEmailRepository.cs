using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSite.EmailService.Domain.Entities;

namespace TestSite.EmailService.Domain.Abstractions;

public interface IEmailRepository
{
	Task<ProductInStockEmailSubscriber> CreateProductInStockEmailSubscriber(ProductInStockEmailSubscriber subscriber);

	Task<List<string>> GetProductInStockEmailSubscribers(int productId);
}