namespace TestSite.Contracts.Requests.Email;

public record CreateProductBackInStockSubscriberRequest
{
	public int ProductId { get; set; }

	public string EmailAddress { get; set; }
}
