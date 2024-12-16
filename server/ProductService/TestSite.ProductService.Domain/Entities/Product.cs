using TestSite.ProductService.Domain.Args;

namespace TestSite.ProductService.Domain.Entities;

public class Product
{
	public Product(ProductArgs args)
	{
		ProductName = args.ProductName;
		ItemNumber = args.ItemNumber;
		ProductDescription = args.ProductDescription;
		Quantity = 0;
		Cost = args.Cost;
		UnitPrice = args.UnitPrice;
	}

	public Product()
	{
		// For EF Core
	}

	public decimal Cost { get; set; }

	public string ItemNumber { get; set; }

	public string ProductDescription { get; set; }

	public int ProductId { get; set; }

	public string ProductName { get; set; }

	public int Quantity { get; set; }

	public decimal UnitPrice { get; set; }

	public void UpdateQuantity(int newQuantity)
	{
		Quantity = newQuantity;
	}
}
