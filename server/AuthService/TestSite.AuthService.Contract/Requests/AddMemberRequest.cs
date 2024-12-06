using TestSite.AuthService.Contract.Models;

namespace TestSite.AuthService.Contract.Requests;

public class AddMemberRequest
{
	public int DepartmentId { get; set; }

	public string EmailAddress { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string PhoneNumber { get; set; }
}