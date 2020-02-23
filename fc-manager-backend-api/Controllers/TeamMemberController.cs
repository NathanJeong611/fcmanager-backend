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
    public class TeamMemberController : ControllerBase
    {
        private readonly ILogger<TeamMemberController> _logger;
        private ITeamMemberRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TeamMemberController(ILogger<TeamMemberController> logger, ITeamMemberRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            //_repoWrapper = repoWrapper;
            _repository = repository;
        }
    }
}
