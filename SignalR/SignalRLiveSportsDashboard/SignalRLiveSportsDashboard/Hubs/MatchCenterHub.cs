using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLiveSportsDashboard.Hubs
{
    public class MatchCenterHub : Hub
    {
        public async Task SendMatchCenterUpdate()
        {
            await Clients.All.SendAsync("RefreshMatchCenter");
        }
    }
}
