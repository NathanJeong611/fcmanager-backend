using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using fc_manager_backend_abstraction;
using fc_manager_backend_api.Controllers.Resources;
using fc_manager_backend_da.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fc_manager_backend_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeagueController : ControllerBase
    {
        private readonly ILogger<LeagueController> _logger;
        private ILeagueRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LeagueController(ILogger<LeagueController> logger, ILeagueRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            //_repoWrapper = repoWrapper;
            _repository = repository;
        }


        [HttpGet]
        public async Task<IEnumerable<LeagueResource>> GetLeagueStandings(int leagueId)
        {
            //var teams = await _repository.GetTeams(leagueId);
            var standings = new int[][]{};
            var matches = await _repository.GetLeagueMatches(leagueId);

            foreach(var match in matches)
            {
                if(match.HomeScore > match.AwayScore)
                {
                    standings[match.HomeTeamId][0]++;
                    standings[match.AwayTeamId][2]++;
                    standings[match.HomeTeamId][3] += match.HomeScore;
                    standings[match.HomeTeamId][4] += match.AwayScore;
                    standings[match.AwayTeamId][3] += match.AwayScore;
                    standings[match.AwayTeamId][4] += match.HomeScore;
                }

                if(match.HomeScore == match.AwayScore)
                {
                    standings[match.HomeTeamId][1]++;
                    standings[match.AwayTeamId][1]++;
                }
            }
            //var result = _mapper.Map<IEnumerable<League>, IEnumerable<LeagueResource>>(leagueStandings);
            return null;
        }
    }
}
