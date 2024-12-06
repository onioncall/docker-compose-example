namespace TestSite.AuthService.Contract.Requests;

public class AddCredentialsRequest
{
	public int MemberId { get; set; }

	public string Password { get; set; }
}