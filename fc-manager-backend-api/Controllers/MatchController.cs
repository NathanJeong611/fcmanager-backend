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
    public class MatchController : ControllerBase
    {
        private readonly ILogger<MatchController> _logger;
        private IMatchRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MatchController(ILogger<MatchController> logger, IMatchRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            //_repoWrapper = repoWrapper;
            _repository = repository;
        }

         [HttpPost]
        public async Task<IActionResult> CreateMatch([FromBody] MatchResource matchResource)
        {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var match = _mapper.Map<MatchResource, Match>(matchResource);

        _repository.Add(match);
        await _unitOfWork.CompleteAsync();

        match = await _repository.GetMatch(match.Id);

        var result = _mapper.Map<Match, MatchResource>(match);

        return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<MatchResource> UpdateMatch(int id, [FromBody] SaveMatchResource matchResource)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState);

            var match = await _repository.GetMatch(id);

            // if (match == null)
            //     return NotFound();

            _mapper.Map<SaveMatchResource, Match>(matchResource, match);

            await _unitOfWork.CompleteAsync();

            match = await _repository.GetMatch(match.Id);
            var result = _mapper.Map<Match, MatchResource>(match);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _repository.GetMatch(id);

            if (match == null)
                return NotFound();

            match.DeletedAt = DateTime.Now;
            //_repository.Remove(member);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {
            var match = await _repository.GetMatch(id);

            if (match == null)
                return NotFound();

            var matchResource = _mapper.Map<Match, MatchResource>(match);

            return Ok(matchResource);
        }

        [HttpGet]
        public async Task<List<QueryResultResource<MatchResource>>> GetMatchResources()
        {
            var matches = await _repository.GetScheduledMatches();

            var result = _mapper.Map<List<QueryResult<Match>>, List<QueryResultResource<MatchResource>>>(matches);
            return result;
        }
    }
}
