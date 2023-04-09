using SignalRLiveSportsDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLiveSportsDashboard.Services
{
    public interface IFootballService
    {
        Task<IEnumerable<MatchViewModel>> GetMatchesAsync();
        Task UpdateMatchAsync(MatchUpdateModel model);
    }
}
