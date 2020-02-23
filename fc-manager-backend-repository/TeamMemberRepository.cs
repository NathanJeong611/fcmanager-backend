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
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private FCMContext _context;
        public TeamMemberRepository(FCMContext context)
        {
            _context = context;
        }

        public void Add(TeamMember TeamMember)
        {
            _context.TeamMembers.Add(TeamMember);
        }

        public void Remove(TeamMember TeamMember)
        {
            _context.TeamMembers.Remove(TeamMember);
        }
    }
}
