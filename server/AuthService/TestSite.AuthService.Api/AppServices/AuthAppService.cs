using AutoMapper;
using TestSite.AuthService.Api.Abstractions;
using TestSite.AuthService.Domain.Entities;
using TestSite.AuthService.Domain.Args;
using TestSite.AuthService.Domain.Abstractions;
using TestSite.AuthService.Contract.Models;
using TestSite.AuthService.Contract.Requests;

namespace TestSite.AuthService.Api.AppServices;

public class AuthAppService : IAuthAppService
{
	private readonly IMapper _mapper;
	private readonly IMemberCredentialsRepository _memberCredRepo;
	private readonly IMemberRepository _memberRepo;

	public AuthAppService(IMemberRepository memberRepo, IMemberCredentialsRepository memberCredRepo, IMapper mapper)
	{
		_memberRepo = memberRepo;
		_memberCredRepo = memberCredRepo;
		_mapper = mapper;
	}

	public async Task<MemberDto> AddMember(AddMemberRequest request)
	{
		try
		{
			var args = _mapper.Map<MemberArgs>(request);
			var memberToAdd = new Member(args);

			var member = await _memberRepo.AddMember(memberToAdd);
			var memberDto = _mapper.Map<MemberDto>(member);
			return memberDto;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public async Task AddMemberCredentials(int memberId, string password)
	{
		try
		{
			await _memberRepo.AddMemberCredentials(memberId, password);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public async Task<MemberDto> GetMemberById(int manufacturerId)
	{
		try
		{
			var member = await _memberRepo.GetByIdAsync(manufacturerId);
			var memberDto = _mapper.Map<MemberDto>(member);

			return memberDto;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public async Task<bool> LoginMember(string username, string password)
	{
		try
		{
			var credentials = await _memberCredRepo.GetCredentials(username);
			var loginVerified = credentials.VerifyLogin(password);

			if

			return loginVerified;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public async Task UpdateMemberCredentials(int memberId, string password)
	{
		try
		{
			await _memberRepo.UpdateMemberCredentials(memberId, password);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}