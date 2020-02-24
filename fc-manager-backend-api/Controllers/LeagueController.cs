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

        [HttpGet("{clubId}")]
        public async Task<IEnumerable<LeagueResource>> GetLeagues(int clubId)
        {
            var leagues = await _repository.GetLeagues(clubId);

            var result = _mapper.Map<IEnumerable<League>, IEnumerable<LeagueResource>>(leagues);
            return result;
        }


        [HttpGet("{leagueId}/standings")]
        public async Task<IEnumerable<LeagueStandingResource>> GetLeagueStandings(int leagueId)
        {
            var teams = await _repository.GetLeagueTeams(leagueId);

            var standings = new int[teams.Count()+1,5];
            var matches = await _repository.GetLeagueMatches(leagueId);

            foreach(var match in matches)
            {
                if(match.HomeScore > match.AwayScore)
                {
                    standings[match.HomeTeamId,0]++;
                    standings[match.AwayTeamId,2]++;
                    standings[match.HomeTeamId,3] += match.HomeScore;
                    standings[match.HomeTeamId,4] += match.AwayScore;
                    standings[match.AwayTeamId,3] += match.AwayScore;
                    standings[match.AwayTeamId,4] += match.HomeScore;
                }

                if(match.HomeScore < match.AwayScore)
                {
                    standings[match.AwayTeamId,0]++;
                    standings[match.HomeTeamId,2]++;
                    standings[match.AwayTeamId,3] += match.AwayScore;
                    standings[match.AwayTeamId,4] += match.HomeScore;
                    standings[match.HomeTeamId,3] += match.HomeScore;
                    standings[match.HomeTeamId,4] += match.AwayScore;
                }

                if(match.HomeScore == match.AwayScore)
                {
                    standings[match.HomeTeamId,1]++;
                    standings[match.AwayTeamId,1]++;
                }
            }

            var result = teams.Select(t => new LeagueStandingResource {
                TeamId = t.Id,
                TeamName = t.Name,
                TeamLogoUrl = t.LogoUrl,
                Played = standings[t.Id, 0] + standings[t.Id, 1] + standings[t.Id, 2],
                Won = standings[t.Id, 0],
                Drawn  = standings[t.Id, 1],
                Lost = standings[t.Id, 2],
                GoalFor = standings[t.Id,3],
                GoalAgainst = standings[t.Id,4],
                GoalDifference = standings[t.Id,3] - standings[t.Id,4],
                Points = standings[t.Id, 0] * 3 + standings[t.Id, 1],
            }).OrderByDescending(ob => ob.Points).ThenByDescending(tb => tb.GoalDifference).ThenByDescending(tb => tb.GoalFor).ToList();
            
            return result;
        }

        [HttpGet("{leagueId}/matchrecords")]
        public async Task<List<QueryResultResource<MatchRecordScoreResource>>> GetLeagueMatchRecords(int leagueId)
        {
            //var matchRecords = await _repository.GetLeagueMatchRecords(leagueId);

            var scoreRecords = await _repository.GetLeagueMatchRecords(leagueId);


            var result = _mapper.Map<List<QueryResult<MatchRecord>>, List<QueryResultResource<MatchRecordScoreResource>>>(scoreRecords);

            return result;
        }
    }
}
