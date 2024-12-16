namespace TestSite.Contracts.Requests.Product;

public record ProductUpdateQuantityRequest
{
	public int ProductId { get; set; }

	public int Quantity { get; set; }
}
