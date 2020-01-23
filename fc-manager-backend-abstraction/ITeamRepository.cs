using System;
using System.Collections.Generic;

namespace fc_manager_backend_abstraction
{
    public interface ITeamRepository
    {
        List<TeamInfo> GetTeams(int ClubId);
        TeamInfo GetTeam(int TeamId);
    }

    public class TeamInfo{
        public int Id {get;set;}
        public string Name {get; set;}
        public string URL {get;set;}
    }
}
