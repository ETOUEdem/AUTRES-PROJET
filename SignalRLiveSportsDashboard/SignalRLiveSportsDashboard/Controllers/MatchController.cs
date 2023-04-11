using Microsoft.AspNetCore.Mvc;
using SignalRLiveSportsDashboard.Models;
using SignalRLiveSportsDashboard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLiveSportsDashboard.Controllers
{
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IFootballService _footballService;
        public MatchController(IFootballService footballService)
        {
            _footballService = footballService;

        }
        [HttpGet]
        [Route("api/Matches")]
        public async Task<IEnumerable<MatchViewModel>> GetMatchesAsync()
        {
            return await _footballService.GetMatchesAsync();
        }
    }
}
