namespace TestSite.Contract.Requests.Auth;

public class AddCredentialsRequest
{
	public int MemberId { get; set; }

	public string Password { get; set; }
}
