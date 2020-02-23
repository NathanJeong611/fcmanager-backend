using System.Collections;
using System;
using System.Collections.Generic;
using fc_manager_backend_da.Models;
using System.Threading.Tasks;

namespace fc_manager_backend_abstraction
{
    public interface ITeamMemberRepository
    {
        void Add(TeamMember member);
        void Remove(TeamMember member);
    }
}
