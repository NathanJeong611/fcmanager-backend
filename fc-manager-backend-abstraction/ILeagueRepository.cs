using System.Collections;
using System;
using System.Collections.Generic;
using fc_manager_backend_da.Models;
using System.Threading.Tasks;

namespace fc_manager_backend_abstraction
{
    public interface ILeagueRepository
    {
        // Task<Member> GetMember(int id);
        Task<IEnumerable<Match>> GetLeagueMatches(int leagueId);
        Task<IEnumerable<Team>> GetLeagueTeams(int leagueId);
        // void Add(Member member);
        // void Remove(Member member);
    }

}
