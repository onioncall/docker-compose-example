namespace TestSite.AuthService.Contract.Requests;

public class MemberLoginRequest
{
	public string Password { get; set; }

	public string Username { get; set; }
}