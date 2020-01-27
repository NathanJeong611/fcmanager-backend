using AutoMapper;
using fc_manager_backend_api.Controllers.Resources;
using fc_manager_backend_da.Models;
using System.Linq;

namespace fc_manager_backend_api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Member, MemberResource>()
                .ForMember(mr => mr.Id, opt => opt.MapFrom(m => m.Id));

            // API Resource to Domain
            CreateMap<MemberResource, Member>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Name, opt => opt.MapFrom(mr => mr.Name)) //opt: operation object
                .ForMember(m => m.Email, opt => opt.MapFrom(mr => mr.Email))
                .ForMember(m => m.Phone, opt => opt.MapFrom(mr => mr.Phone))
                .ForMember(m => m.StartedOn, opt => opt.MapFrom(mr => mr.StartedOn))
                .ForMember(m => m.RoleId, opt => opt.MapFrom(mr => mr.RoleId))
                .ForMember(m => m.ClubId, opt => opt.MapFrom(mr => mr.ClubId))
                .ForMember(m => m.Id, opt => opt.MapFrom(mr => mr.TeamMembers.FirstOrDefault(x => x.Id == mr.Id)))
                .ForMember(m => m.ImageUrl, opt => opt.MapFrom(mr => mr.ImageUrl))
                .ForMember(m => m.DOB, opt => opt.MapFrom(mr => mr.DOB));
        }
    }
}