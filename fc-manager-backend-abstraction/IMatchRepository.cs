using System;
using System.Collections.Generic;
using fc_manager_backend_da.Models;
using fc_manager_backend_abstraction;
using System.Threading.Tasks;
using System.Linq;

namespace fc_manager_backend_abstraction
{
    public interface IMatchRepository
    {
        Task<Match> GetMatch(int id);
        Task<IEnumerable<Match>> GetMatches();
        Task<IEnumerable<MatchRecord>> GetMatchRecords(int id);
        //Task<List<QueryResult<Match>>> GetScheduledMatches();
        void Add(Match match);
        void Remove(Match match);
    }
}
