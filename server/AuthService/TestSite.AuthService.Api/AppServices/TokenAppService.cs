using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TestSite.AuthService.Api.Abstractions;
using TestSite.AuthService.Domain.Entities;

namespace TestSite.AuthService.Api.AppServices;

public class TokenAppService : ITokenAppService
{
	private readonly IConfiguration _configuration;

	public TokenAppService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string GenerateJwtToken(int memberId, DepartmentType department)
	{
		var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Name, memberId.ToString()),
				new Claim(ClaimTypes.Role, department.ToString())
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
