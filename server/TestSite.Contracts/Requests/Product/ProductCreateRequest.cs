namespace TestSite.Contracts.Requests.Product;

public class ProductCreateRequest
{
	public decimal Cost { get; set; }

	public string ItemNumber { get; set; }

	public string ProductDescription { get; set; }

	public string ProductName { get; set; }

	public decimal UnitPrice { get; set; }
}
