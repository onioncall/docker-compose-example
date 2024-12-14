using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSite.ProductService.Domain.Args;

public class ProductArgs
{
	public decimal Cost { get; set; }

	public string ItemNumber { get; set; }

	public string ProductDescription { get; set; }

	public string ProductName { get; set; }

	public decimal UnitPrice { get; set; }
}