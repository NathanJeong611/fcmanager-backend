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
                                        //.Where(t => t. == leagueId && m.DeletedAt != null)
                                        .ToListAsync();
            
            return result;
        }
        public async Task<IEnumerable<Match>> GetLeagueMatches(int leagueId)
        {
            var result = await _context.Matches
                                        .Where(m => m.LeagueId == leagueId && m.DeletedAt != null)
                                        .ToListAsync();
            
            return result;
        }
    }
}
