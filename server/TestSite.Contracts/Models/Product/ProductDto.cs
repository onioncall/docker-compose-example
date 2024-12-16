namespace TestSite.Contracts.Models.Product;

public class ProductDto
{
	public decimal Cost { get; set; }

	public string ItemNumber { get; set; }

	public string ProductDescription { get; set; }

	public int ProductId { get; set; }

	public string ProductName { get; set; }

	public int Quantity { get; set; }

	public decimal UnitPrice { get; set; }
}
