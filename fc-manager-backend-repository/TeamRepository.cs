using System.Security.Cryptography.X509Certificates;
using fc_manager_backend_da.Models;
using fc_manager_backend_abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fc_manager_backend_repository
{
    public class TeamRepository : ITeamRepository
    {
        private FCMContext _context;
        public TeamRepository(FCMContext context)
        {
            _context = context;
        }

        public TeamInfo GetTeam(int teamId)
        {
            return _context.Teams.Where(t => t.Id == teamId && t.DeletedAt == null)
                            .Select(t => new TeamInfo{ Id = t.Id, Name = t.Name, URL = t.LogoUrl}).FirstOrDefault();
        }

        public List<TeamInfo> GetTeams(int clubId)
        {
            var list = (from t in _context.Teams
                        where t.ClubId == clubId && t.DeletedAt == null
                        select t).ToList();

            return _context.Teams.Where(t => t.ClubId == clubId && t.DeletedAt == null)
                            .Select(t => new TeamInfo{ Id = t.Id, Name = t.Name, URL = t.LogoUrl}).ToList();
        }
    }
}
