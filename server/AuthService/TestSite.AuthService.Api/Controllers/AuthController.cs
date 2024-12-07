using Microsoft.AspNetCore.Mvc;
using TestSite.AuthService.Api.Abstractions;
using TestSite.AuthService.Contract.Requests;

namespace TestSite.AuthService.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly IAuthAppService _authAppService;
	private readonly IConfiguration _configuration;
	private readonly ILogger<AuthController> _logger;

	public AuthController(ILogger<AuthController> logger, IAuthAppService authAppService, IConfiguration configuration)
	{
		_logger = logger;
		_authAppService = authAppService;
		_configuration = configuration;
	}

	[HttpPost]
	[Route("create-member")]
	public async Task<IActionResult> CreateMember(AddMemberRequest request)
	{
		try
		{
			var member = await _authAppService.AddMember(request);

			if (member == null)
			{
				return NotFound();
			}

			return Ok(member);
		}
		catch (Exception ex)
		{
			var message = $"Error Creating Member: {request.EmailAddress}";
			_logger.LogError(ex, message);
			return BadRequest(message);
		}
	}

	[HttpPost]
	[Route("create-credentials")]
	public async Task<IActionResult> CreateMemberCredentials(AddCredentialsRequest request)
	{
		try
		{
			await _authAppService.AddMemberCredentials(request.MemberId, request.Password);

			return Ok();
		}
		catch (Exception ex)
		{
			var message = $"Error Creating Member Credentials: {request.MemberId}";
			_logger.LogError(ex, message);
			return BadRequest(message);
		}
	}

	[HttpGet]
	public async Task<IActionResult> GetMemberById([FromQuery] int id)
	{
		try
		{
			var member = await _authAppService.GetMemberById(id);

			if (member == null)
			{
				return NotFound();
			}

			return Ok(member);
		}
		catch (Exception ex)
		{
			var message = $"Error Getting Member by ID: {id}";
			_logger.LogError(ex, message);
			return BadRequest(message);
		}
	}

	[HttpPost]
	[Route("login-member")]
	public async Task<IActionResult> LoginMember([FromBody] MemberLoginRequest request)
	{
		var token = await _authAppService.LoginMember(request.Username, request.Password);

		return Ok(token);
	}

	[HttpPut]
	[Route("update-credentials")]
	public async Task<IActionResult> UpdateMemberCredentials(AddCredentialsRequest request)
	{
		try
		{
			await _authAppService.UpdateMemberCredentials(request.MemberId, request.Password);

			return Ok();
		}
		catch (Exception ex)
		{
			var message = $"Error Creating Member Credentials: {request.MemberId}";
			_logger.LogError(ex, message);
			return BadRequest(message);
		}
	}
}
