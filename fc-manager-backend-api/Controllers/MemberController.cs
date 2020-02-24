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
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private IMemberRepository _repository;
        private ITeamMemberRepository _teamMeberRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(ILogger<MemberController> logger, IMemberRepository repository, ITeamMemberRepository teamMemberRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            //_repoWrapper = repoWrapper;
            _repository = repository;
            _teamMeberRepository = teamMemberRepository;
        }

        [HttpPost]
        public async Task<MemberResource> CreateMember([FromBody] MemberResource memberResource)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState);

            var member = _mapper.Map<MemberResource, Member>(memberResource);

            _repository.Add(member);

            await _unitOfWork.CompleteAsync();
            
            //Add TeamMember
            if(memberResource.TeamId > 0)
            {
                var teamMember = new TeamMember { MemberId = member.Id, TeamId = memberResource.TeamId };
                _teamMeberRepository.Add(teamMember);
            }

            await _unitOfWork.CompleteAsync();

            member = await _repository.GetMember(member.Id);

            var result = _mapper.Map<Member, MemberResource>(member);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<MemberResource> UpdateMember(int id, [FromBody] SaveMemberResource memberResource)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState);

            var member = await _repository.GetMember(id);

            // if (member == null)
            //     return NotFound();

            _mapper.Map<SaveMemberResource, Member>(memberResource, member);

            //Find LeagueTeamMember
            var leagueTeamMembers = member.TeamMembers
                                .Where(tm => tm.DeletedAt == null 
                                            && tm.TeamId > 0 
                                            && tm.Team.LeagueId == memberResource.LeagueId)
                                .FirstOrDefault();

            if(memberResource.TeamId > 0)
            {
                if (leagueTeamMembers == null) //Add League TeamMember
                {
                    var teamMember = new TeamMember { MemberId = member.Id, TeamId = memberResource.TeamId };
                    _teamMeberRepository.Add(teamMember);
                } else //Update League Team Member
                {
                    leagueTeamMembers.TeamId = memberResource.TeamId;
                }
            } else //Remove exist TeamMember when TeamId is none
            {
                if (leagueTeamMembers != null)
                {
                    leagueTeamMembers.DeletedAt = DateTime.Now;
                }
            }

            await _unitOfWork.CompleteAsync();

            member = await _repository.GetMember(member.Id);
            var result = _mapper.Map<Member, MemberResource>(member);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _repository.GetMember(id);

            if (member == null)
                return NotFound();

            member.DeletedAt = DateTime.Now;
            //_repository.Remove(member);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var member = await _repository.GetMember(id);

            if (member == null)
                return NotFound();

            var memberResource = _mapper.Map<Member, MemberResource>(member);

            return Ok(memberResource);
        }

        [HttpGet]
        public async Task<IEnumerable<MemberResource>> GetMemberResources()
        {
            var members = await _repository.GetMembers();

            var result = _mapper.Map<IEnumerable<Member>, IEnumerable<MemberResource>>(members);
            return result;
        }
    }
}
