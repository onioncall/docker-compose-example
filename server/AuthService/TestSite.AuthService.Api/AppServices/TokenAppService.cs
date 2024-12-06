// Services/TokenService.cs
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TestSite.AuthService.Domain.Entities;

namespace TestSite.AuthService.Api.AppServices;

public class TokenAppService
{
	private readonly IConfiguration _configuration;

	public TokenAppService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string GenerateJwtToken(Member member)
	{
		var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Name, member.MemberId.ToString()),
				new Claim(ClaimTypes.Role, member.Department.ToString())
			}),
			Expires = DateTime.UtcNow.AddMinutes(5),
			SigningCredentials = new SigningCredentials(
				new SymmetricSecurityKey(key),
				SecurityAlgorithms.HmacSha256Signature)
		};
		
		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}
