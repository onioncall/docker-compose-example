using System.Security.Cryptography;
using System.Text;

namespace TestSite.AuthService.Domain.Entities;

public class MemberCredentials
{
	private readonly int minimumPasswordLength = 10;

	private readonly string salt = ""; //this should be injected as an environment variable

	public MemberCredentials()
	{
		// For EF core
	}

	public MemberCredentials(Member member, string password)
	{
		if (member == null || password == null)
		{
			throw new Exception("Member Credentials can not be null.");
		}

		Member = member;
		HashedPassword = HashPassword(password, salt);
	}

	public string HashedPassword { get; set; }

	public Member Member { get; private set; }

	public int MemberCredentialsId { get; set; }

	public int MemberId { get; set; }

	public void UpdateCredentials(string password)
	{
		HashedPassword = HashPassword(password, salt);
	}

	public bool VerifyLogin(string password)
	{
		var hashedInputPassword = HashPassword(password, salt);

		if (hashedInputPassword == HashedPassword)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private string HashPassword(string password, string salt)
	{
		StringBuilder Sb = new StringBuilder();

		using (var hash = SHA256.Create())
		{
			Encoding enc = Encoding.UTF8;
			byte[] result = hash.ComputeHash(enc.GetBytes(password + salt));

			foreach (byte b in result)
				Sb.Append(b.ToString("x2"));
		}

		return Sb.ToString();
	}

	private void ValidatePassword(string password)
	{
		if (password.Length > minimumPasswordLength)
		{
			throw new Exception("Password does not meet requirements");
		}
	}
}