using System.Net.NetworkInformation;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using fc_manager_backend_da.Models;
using fc_manager_backend_abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace fc_manager_backend_repository
{
    public class LeagueRepository : ILeagueRepository
    {
        private FCMContext _context;
        public LeagueRepository(FCMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<League>> GetLeagues(int clubId)
        {
            return await _context.League
                                .Where(t => t.ClubId == clubId && t.DeletedAt == null)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Team>> GetLeagueTeams(int leagueId)
        {
            return await _context.Teams
                                .Where(t => t.LeagueId == leagueId && t.DeletedAt == null)
                                .ToListAsync();
        }
        public async Task<IEnumerable<Match>> GetLeagueMatches(int leagueId)
        {
            return await _context.Matches
                                .Where(m => m.LeagueId == leagueId && m.DeletedAt == null)
                                .ToListAsync();
        }

        public async Task<List<QueryResult<MatchRecord>>> GetLeagueMatchRecords(int leagueId)
        {
            var result = new List<QueryResult<MatchRecord>>();

            var matchRecords = _context.MatchRecords
                                .Where(m => m.Match.LeagueId == leagueId && m.DeletedAt == null)
                                .Include(mr => mr.ScoreMember)
                                    .ThenInclude(mrm => mrm.TeamMembers)
                                        .ThenInclude(tm => tm.Team)
                                .Include(mr => mr.AssistMember)
                                    .ThenInclude(mrm => mrm.TeamMembers)
                                        .ThenInclude(tm => tm.Team)
                                .Include(mr => mr.Type)
                                .AsEnumerable();

            var scoreReocrds = (matchRecords
                                .GroupBy(m => (m.ScoreMemberId, m.ScoreMember))
                                .Select(g => new QueryResult<MatchRecord>
                                {
                                    Type = "score",
                                    MemberId = g.Key.ScoreMemberId ?? 0,
                                    MemberName = g.Key.ScoreMember.Name,
                                    TeamId = g.Key.ScoreMember.TeamMembers.FirstOrDefault(tm => tm.Team.LeagueId == leagueId).TeamId,
                                    TeamName = g.Key.ScoreMember.TeamMembers.FirstOrDefault(tm => tm.Team.LeagueId == leagueId).Team.Name,
                                    TeamLogoUrl = g.Key.ScoreMember.TeamMembers.FirstOrDefault(tm => tm.Team.LeagueId == leagueId).Team.LogoUrl,
                                    Count = g.Count()
                                }));

            var assistRecords = (matchRecords
                                .GroupBy(m => (m.AssistMemberId, m.AssistMember))
                                .Select(g => new QueryResult<MatchRecord>
                                {
                                    Type = "assist",
                                    MemberId = g.Key.AssistMemberId ?? 0,
                                    MemberName = g.Key.AssistMember.Name,
                                    TeamId = g.Key.AssistMember.TeamMembers.FirstOrDefault(tm => tm.Team.LeagueId == leagueId).TeamId,
                                    TeamName = g.Key.AssistMember.TeamMembers.FirstOrDefault(tm => tm.Team.LeagueId == leagueId).Team.Name,
                                    TeamLogoUrl = g.Key.AssistMember.TeamMembers.FirstOrDefault(tm => tm.Team.LeagueId == leagueId).Team.LogoUrl,
                                    Count = g.Count()
                                }));
            
            var leagueMatchRecords = scoreReocrds.Concat(assistRecords).ToList();

            result = await Task.FromResult(leagueMatchRecords);
            return result;
        }
    }
}
