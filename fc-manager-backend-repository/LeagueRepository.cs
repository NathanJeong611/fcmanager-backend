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

        public async Task<IEnumerable<Team>> GetLeagueTeams(int leagueId)
        {
            var result = await _context.Teams
                                        .Where(t => t.LeagueId == leagueId && t.DeletedAt == null)
                                        .ToListAsync();
            
            return result;
        }
        public async Task<IEnumerable<Match>> GetLeagueMatches(int leagueId)
        {
            var result = await _context.Matches
                                        .Where(m => m.LeagueId == leagueId && m.DeletedAt == null)
                                        .ToListAsync();
            
            return result;
        }
        public async Task<IEnumerable<MatchRecord>> GetLeagueMatchRecords(int leagueId)
        {
            var result = await _context.MatchRecords
                                        .Where(m => m.Match.LeagueId == leagueId && m.DeletedAt == null)
                                        .Include(mr => mr.ScoreMember)
                                            .ThenInclude(mrm => mrm.TeamMembers)
                                        .Include(mr => mr.AssistMember)
                                            .ThenInclude(mrm => mrm.TeamMembers)
                                        .Include(mr => mr.Type)
                                        .ToListAsync();
            return result;
        }

        public async Task<List<QueryResult<MatchRecord>>> GetScoreRecords(int leagueId)
        {
            var result = new List<QueryResult<MatchRecord>>();

            var query = (_context.MatchRecords
                                .Where(m => m.Match.LeagueId == leagueId && m.DeletedAt == null)
                                .Include(mr => mr.ScoreMember)
                                    .ThenInclude(mrm => mrm.TeamMembers)
                                .Include(mr => mr.AssistMember)
                                    .ThenInclude(mrm => mrm.TeamMembers)
                                .Include(mr => mr.Type)
                                .AsEnumerable()
                                .GroupBy(m => (m.ScoreMemberId, m.ScoreMember ))
                                .Select(g => new QueryResult<MatchRecord>
                                {
                                    MemberId = g.Key.ScoreMemberId ?? 0,
                                    Member = g.Key.ScoreMember,
                                    RecordCount = g.Count()
                                })).ToList();


            result = await Task.FromResult(query);
            return result;
        }
    }
}
