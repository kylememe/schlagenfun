using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schlagenfun.Services.Teams.API.Model;

namespace Schlagenfun.Services.Teams.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {

        private readonly ILogger<TeamsController> _logger;

        public TeamsController(ILogger<TeamsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Team> Get()
        {
            var teams = new IEnumerable<Team>();            
            return teams;
        }
    }
}
