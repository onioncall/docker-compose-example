using TestSite.AuthService.Domain.Entities;

namespace TestSite.AuthService.Domain.Args;

public class MemberArgs
{
	public int DepartmentId { get; set; }

	public string EmailAddress { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string PhoneNumber { get; set; }
}