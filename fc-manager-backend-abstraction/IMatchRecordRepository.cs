using System;
using System.Collections.Generic;
using fc_manager_backend_da.Models;
using fc_manager_backend_abstraction;
using System.Threading.Tasks;
using System.Linq;

namespace fc_manager_backend_abstraction
{
    public interface IMatchRecordRepository
    {
        Task<MatchRecord> GetMatchRecord(int id);
        Task<IEnumerable<MatchRecord>> GetMatchRecords();
        Task<List<MatchRecord>> GetMatchRecords(List<int> matchRecordIds);
        void Add(MatchRecord matchRecord);
        void Remove(MatchRecord matchRecord);
    }
}
