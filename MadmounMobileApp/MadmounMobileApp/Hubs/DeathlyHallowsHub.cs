using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace MadmounMobileApp.Hubs
{
    public class DeathlyHallowsHub : Hub
    {
        public Dictionary<string,int> GetRaceStatus()
        {
            return SD.DealthyHallowRace;
        }
    }
}
