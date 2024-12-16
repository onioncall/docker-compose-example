using AutoMapper;
using TestSite.Contract.Requests.Auth;
using TestSite.Contract.Models.Auth;
using TestSite.AuthService.Domain.Args;
using TestSite.AuthService.Domain.Entities;

namespace TestSite.AuthService.Api;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<Member, MemberDto>().ReverseMap();
		CreateMap<MemberArgs, AddMemberRequest>().ReverseMap();
	}
}
