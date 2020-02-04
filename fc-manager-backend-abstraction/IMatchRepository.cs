using System;
using System.Collections.Generic;
using fc_manager_backend_da.Models;
using System.Threading.Tasks;

namespace fc_manager_backend_abstraction
{
    public interface IMatchRepository
    {
        Task<Match> GetMatch(int id);
        Task<IEnumerable<Match>> GetScheduledMatches();
        void Add(Match match);
        void Remove(Match match);
    }
}
