using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fc_manager_backend_abstraction
{
    public interface IRepositoryWrapper
    {
        IMatchRepository Match { get; }
        ITeamRepository Team {get;}
        
    }
}
