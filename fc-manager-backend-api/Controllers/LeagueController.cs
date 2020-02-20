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
        public async Task<IEnumerable<LeagueResource>> GetLeagueStandings(int id)
        {
            var leagueStandings = await _repository.GetLeagueStandings(id);

            var result = _mapper.Map<IEnumerable<League>, IEnumerable<LeagueResource>>(leagueStandings);
            return result;
        }
    }
}
