using System;
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
                .ForMember(mr => mr.HomeTeamLogoUrl, opt => opt.MapFrom(m => m.HomeTeam.LogoUrl))
                .ForMember(mr => mr.AwayTeamLogoUrl, opt => opt.MapFrom(m => m.AwayTeam.LogoUrl))
                .ForMember(mr => mr.ScheduledOn, opt => opt.MapFrom(m => m.ScheduledAt.Date));
            CreateMap<MatchRecord, MatchRecordResource>()
                .ForMember(mr => mr.ScoreTeamId, opt => opt.MapFrom(m => m.ScoreMember.TeamMembers.FirstOrDefault(tm => tm.MemberId == m.ScoreMember.Id).TeamId))
                .ForMember(mr => mr.AssistTeamId, opt => opt.MapFrom(m => m.AssistMember.TeamMembers.FirstOrDefault(tm => tm.MemberId == m.AssistMember.Id).TeamId));
                
            // API Resource to Domain
            CreateMap<MemberResource, Member>();
            CreateMap<SaveMemberResource, Member>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<MatchResource, Match>();
            CreateMap<SaveMatchResource, Match>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<MatchRecordResource, MatchRecord>();
            CreateMap<SaveMatchRecordResource, MatchRecord>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .AfterMap((mr, m) => {
                    // Delete unselected MatchRecords
                    if ((mr.ScoreMemberId == 0 || mr.ScoreMemberId == null) && (mr.AssistMemberId == 0 || mr.AssistMemberId == null))
                        m.DeletedAt = DateTime.Now;
                });
        }
    }
}