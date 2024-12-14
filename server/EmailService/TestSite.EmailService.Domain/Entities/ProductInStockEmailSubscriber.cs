using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSite.EmailService.Domain.Entities;

public class ProductInStockEmailSubscriber
{
	public ProductInStockEmailSubscriber(int productId, string emailAddress)
	{
		ProductId = productId;
		EmailAddress = emailAddress;
		IsSent = false;
	}

	public string EmailAddress { get; set; }

	public bool IsSent { get; set; }

	public int ProductId { get; set; }

	public int ProductInStockEmailSubscriberId { get; set; }
}