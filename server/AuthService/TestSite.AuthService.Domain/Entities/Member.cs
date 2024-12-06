using TestSite.AuthService.Domain.Entities;
using TestSite.AuthService.Domain.Args;

namespace TestSite.AuthService.Domain.Entities;

public class Member
{
	public Member()
	{
		// For EF Core
	}

	public Member(MemberArgs args)
	{
		if (args.FirstName == null) throw new Exception($"{nameof(args.FirstName)} cannot be null when creating member.");
		if (args.LastName == null) throw new Exception($"{nameof(args.LastName)} cannot be null when creating member.");
		if (args.EmailAddress == null) throw new Exception($"{nameof(args.EmailAddress)} cannot be null when creating member.");
		if (args.PhoneNumber == null) throw new Exception($"{nameof(args.PhoneNumber)} cannot be null when creating member.");
		if (args.DepartmentId == null) throw new Exception($"{nameof(args.DepartmentId)} cannot be null when creating member.");

		FirstName = args.FirstName;
		LastName = args.LastName;
		EmailAddress = args.EmailAddress;
		PhoneNumber = args.PhoneNumber;
		Username = CreateUsername(args.EmailAddress);
		Department = (DepartmentType)args.DepartmentId;
	}

	public DepartmentType Department { get; set; }

	public string EmailAddress { get; private set; }

	public string FirstName { get; private set; }

	public string LastName { get; private set; }

	public MemberCredentials? MemberCredentials { get; private set; }

	public int MemberId { get; private set; }

	public string PhoneNumber { get; private set; }

	public string Username { get; set; }

	public void AddCredentials(string password)
	{
		if (MemberCredentials != null)
		{
			throw new Exception($"Member: {MemberId} already has credentials");
		}
		MemberCredentials = new MemberCredentials(this, password);
	}

	public void UpdateCredentials(string password)
	{
		if (MemberCredentials == null)
		{
			throw new Exception($"Member: {MemberId} does not have credentials");
		}

		MemberCredentials.UpdateCredentials(password);
	}

	private string CreateUsername(string email)
	{
		var usernameEmailString = email.Split("@");

		return usernameEmailString[0];
	}
}