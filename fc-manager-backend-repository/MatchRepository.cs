using System.Security.Cryptography.X509Certificates;
using fc_manager_backend_da.Models;
using fc_manager_backend_abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fc_manager_backend_repository
{
    public class MatchRepository : IMatchRepository
    {
        private FCMContext _context;
        public MatchRepository(FCMContext context)
        {
            _context = context;
        }

        public List<ScheduleInfo> GetMatches(int clubId, DateTime? beginingAt)
        {
            var query = _context.Matches.Where(m => m.ClubId == clubId && m.DeletedAt == null);
            if (beginingAt != null)
            {
                query = query.Where(q => beginingAt <= q.ScheduledAt);
            }

            return query.AsEnumerable().GroupBy(m => m.ScheduledAt.Date)
                        .Select(g => new ScheduleInfo
                        {
                            ScheduledOn = g.Key,
                            matches = g.Select(m => new MatchInfo
                            {
                                Id = m.Id,
                                HomeTeamName = m.HomeTeam?.Name,
                                HomeTeamLogoUrl = m.HomeTeam?.LogoUrl,
                                HomeScore = m.HomeScore,
                                AwayTeamName = m.AwayTeam?.Name,
                                AwayTeamLogoUrl = m.AwayTeam?.LogoUrl,
                                AwayScore = m.AwayScore,
                                Location = m.Location,
                                ScheduledAt = m.ScheduledAt
                            }).ToList()
                        }).ToList();
        }
    }
}
