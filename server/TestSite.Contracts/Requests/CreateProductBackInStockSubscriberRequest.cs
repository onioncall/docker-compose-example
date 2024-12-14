using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSite.Contracts.Requests;

public record CreateProductBackInStockSubscriberRequest
{
	public int ProductId { get; set; }

	public string EmailAddress { get; set; }
}