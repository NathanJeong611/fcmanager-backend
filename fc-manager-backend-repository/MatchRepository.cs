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
    public class MatchRepository : IMatchRepository
    {
        private FCMContext _context;
        public MatchRepository(FCMContext context)
        {
            _context = context;
        }

        public void Add(Match match)
        {
            _context.Matches.Add(match);
        }

        public void Remove(Match match)
        {
            _context.Matches.Remove(match);
        }

        public async Task<Match> GetMatch(int id)
        {
            return await _context.Matches.FindAsync(id);
        }

        public async Task<List<QueryResult<Match>>> GetScheduledMatches()
        {
            var result = new List<QueryResult<Match>>();

            var query = _context.Matches
                            .Include(m => m.HomeTeam)
                            .Include(m => m.AwayTeam)
                            .Include(m => m.MatchRecords)
                                .ThenInclude(mr => mr.ScoreMember)
                                    .ThenInclude(mrm => mrm.TeamMembers)
                            .Include(m => m.MatchRecords)
                                .ThenInclude(mr => mr.AssistMember)
                                    .ThenInclude(mrm => mrm.TeamMembers)
                            .Include(m => m.MatchRecords)
                                .ThenInclude(mr => mr.Type)
                            .AsEnumerable()
                            .GroupBy(m => m.ScheduledAt.Date)
                            .Select(g => new QueryResult<Match>
                            {
                                ScheduledOn = g.Key,
                                Matches = g,
                            });
                            
            result = await Task.FromResult(query.ToList());
            return result;
        }
    }
}
