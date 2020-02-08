using System.Runtime.InteropServices;
using AutoMapper;
using fc_manager_backend_api.Controllers.Resources;
using fc_manager_backend_da.Models;
using fc_manager_backend_abstraction;
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
                .ForMember(mr => mr.TeamName, opt => opt.MapFrom(m => m.TeamMembers.FirstOrDefault(f => f.MemberId == m.Id).Team.Name))
                .ForMember(mr => mr.TeamId, opt => opt.MapFrom(m => m.TeamMembers.FirstOrDefault(f => f.MemberId == m.Id).Team.Id));

            CreateMap<Code, CodeResource>();
            CreateMap<Team, TeamResource>();

            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
            CreateMap<Match, MatchResource>()
                .ForMember(mr => mr.HomeTeamName, opt => opt.MapFrom(m => m.HomeTeam.Name))
                .ForMember(mr => mr.AwayTeamName, opt => opt.MapFrom(m => m.AwayTeam.Name))
                .ForMember(mr => mr.MatchRecords, opt => opt.MapFrom(m => m.MatchRecords.Select(mrs => new MatchRecordResource 
                { 
                    Id = mrs.Id,
                    ScoreMemberId = mrs.ScoreMember.Id, 
                    ScoreMemberName = mrs.ScoreMember.Name,
                    ScoreTeamId = mrs.ScoreMember.TeamMembers.Where(f => f.MemberId == mrs.ScoreMember.Id).Select(z => z.TeamId).FirstOrDefault(),
                    AssistMemberId = mrs.AssistMember.Id, 
                    AssistMemberName = mrs.AssistMember.Name,
                    AssistTeamId = mrs.ScoreMember.TeamMembers.Where(f => f.MemberId == mrs.ScoreMember.Id).Select(z => z.TeamId).FirstOrDefault(),
                    CodeId = mrs.CodeId, 
                    CodeName = mrs.Type.Name
                })));
                
            // API Resource to Domain
            CreateMap<MemberResource, Member>();
            CreateMap<SaveMemberResource, Member>()
                .ForMember(m => m.Id, opt => opt.Ignore());
                // .ForMember(m => m.Name, opt => opt.MapFrom(mr => mr.Name)) //opt: operation object
                // .ForMember(m => m.Email, opt => opt.MapFrom(mr => mr.Email))
                // .ForMember(m => m.Phone, opt => opt.MapFrom(mr => mr.Phone))
                // .ForMember(m => m.StartedOn, opt => opt.MapFrom(mr => mr.StartedOn))
                // //.ForMember(m => m.Id, opt => opt.MapFrom(mr => mr.TeamMembers.FirstOrDefault(x => x.Id == mr.Id)))
                // .ForMember(m => m.ImageUrl, opt => opt.MapFrom(mr => mr.ImageUrl))
                // .ForMember(m => m.DOB, opt => opt.MapFrom(mr => mr.DOB));
            CreateMap<MatchResource, Match>();
            CreateMap<SaveMatchResource, Match>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}