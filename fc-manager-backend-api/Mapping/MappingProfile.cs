using System.Runtime.InteropServices;
using AutoMapper;
using fc_manager_backend_api.Controllers.Resources;
using fc_manager_backend_da.Models;
using System.Linq;
using System.Collections.Generic;

namespace fc_manager_backend_api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            //CreateMap(typeof(IEnumerable<Member>), typeof(IEnumerable<MemberResource>));
            //     .ForMember(mr => mr, opt => opt.MapFrom(m => m.Select(s => new { Id = s.Id})));
            //     .ForMember(mr => mr.Id, opt => opt.MapFrom(m => m.))
            // CreateMap<IEnumerable<Member>, IEnumerable<MemberResource>>()
            //     .ForMember(mr => mr, opt => opt.MapFrom(m => m.Select(s => new { Id = s.Id})));
            CreateMap<Member, MemberResource>()
                .ForMember(mr => mr.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(mr => mr.TeamName, opt => opt.MapFrom(m => m.TeamMembers.FirstOrDefault(f => f.MemberId == m.Id).Team.Name));

            // API Resource to Domain
            CreateMap<MemberResource, Member>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Name, opt => opt.MapFrom(mr => mr.Name)) //opt: operation object
                .ForMember(m => m.Email, opt => opt.MapFrom(mr => mr.Email))
                .ForMember(m => m.Phone, opt => opt.MapFrom(mr => mr.Phone))
                .ForMember(m => m.StartedOn, opt => opt.MapFrom(mr => mr.StartedOn))
                //.ForMember(m => m.Id, opt => opt.MapFrom(mr => mr.TeamMembers.FirstOrDefault(x => x.Id == mr.Id)))
                .ForMember(m => m.ImageUrl, opt => opt.MapFrom(mr => mr.ImageUrl))
                .ForMember(m => m.DOB, opt => opt.MapFrom(mr => mr.DOB));
        }
    }
}