using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fc_manager_backend_abstraction;
using fc_manager_backend_da.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fc_manager_backend_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private IRepositoryWrapper _repoWrapper;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public TeamController(ILogger<TeamController> logger, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
        }

        [HttpGet("{clubId}")]
        public IEnumerable<TeamInfo> GetTeams(int clubId)
        {
            return _repoWrapper.Team.GetTeams(clubId);
        }
    }
}
