using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRLiveSportsDashboard.Hubs;
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
        private readonly IHubContext<MatchCenterHub> _hub;
        public MatchController(IFootballService footballService, IHubContext<MatchCenterHub> hub)
        {
            _footballService = footballService;
            _hub = hub;
        }

        [HttpGet]
        [Route("api/Matches")]
        public async Task<IEnumerable<MatchViewModel>> GetMatchesAsync()
        {
            return await _footballService.GetMatchesAsync();
        }

        // POST: api/Matches
        //[HttpPut]
        //[Route("api/Matchess")]
        //public async Task UpdateMatchAsync(MatchUpdateModel model)
        //{
        //    await _footballService.UpdateMatchAsync(model);

        //    //await _hub.Clients.All.SendAsync("RefreshMatchCenter");
        //}


        [HttpPost]
        [Route("api/Matches")]
        public async Task UpdateMatchAsync(MatchUpdateModel model)
        {
       
            await _footballService.UpdateMatchAsync(model);

            await _hub.Clients.All.SendAsync("RefreshMatchCenter");
        }
    }
}
