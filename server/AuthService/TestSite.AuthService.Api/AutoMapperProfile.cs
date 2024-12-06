using AutoMapper;
using TestSite.AuthService.Contract.Models;
using TestSite.AuthService.Contract.Requests;
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