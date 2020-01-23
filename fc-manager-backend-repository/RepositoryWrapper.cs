using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fc_manager_backend_da.Models;
using fc_manager_backend_abstraction;

namespace fc_manager_backend_repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FCMContext _context;
        private IMatchRepository _match;
        private ITeamRepository _team;


        public RepositoryWrapper(FCMContext context)
        {
            _context = context;
        }

        public IMatchRepository Match { get
            {
                if (_match == null)
                    _match = new MatchRepository(_context);
                
                return _match;
            }}

        public ITeamRepository Team { get
            {
                if (_team == null)
                    _team = new TeamRepository(_context);
                
                return _team;
            }}
    }
}
