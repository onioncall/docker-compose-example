namespace TestSite.AuthService.Contract.Models;

public class MemberDto
{
	public int DepartmentId { get; set; }

	public string EmailAddress { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public int MemberId { get; set; }

	public string PhoneNumber { get; set; }

	public string Username { get; set; }
}