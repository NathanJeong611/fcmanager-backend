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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(ILogger<MemberController> logger, IMemberRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            //_repoWrapper = repoWrapper;
            _repository = repository;
        }

        // [HttpGet("{clubId}")]
        // public async Task<IEnumerable<Member>> GetMember(int clubId)
        // {
        //     var members = await _repoWrapper.Member.Include(members => members.).ToListAsync();
        //     await 
        // }

        [HttpPost]
        public async Task<MemberResource> CreateMember([FromBody] MemberResource memberResource)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState);

            var member = _mapper.Map<MemberResource, Member>(memberResource);

            _repository.Add(member);
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
