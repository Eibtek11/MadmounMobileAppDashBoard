using BL;
using MadmounMobileApp.Hubs;
using MadmounMobileApp.Models;
using MadmounMobileApp.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MadmounMobileApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UserManager<ApplicationUser> Usermanager;
        private readonly IHubContext<DeathlyHallowsHub> _deathlyHub;
        private readonly MadmounDbContext _context;
        public HomeController(MadmounDbContext context,IHubContext<DeathlyHallowsHub> deathlyHub, UserManager<ApplicationUser> usermanager, ILogger<HomeController> logger)
        {
            _logger = logger;
            Usermanager = usermanager;
            _deathlyHub = deathlyHub;
            _context = context;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignalR()
        {


            return View();
        }
        public async Task<IActionResult> DeathlyHallows(string type)
        {
            if (SD.DealthyHallowRace.ContainsKey(type))
            {
                SD.DealthyHallowRace[type]++;
            }
            await _deathlyHub.Clients.All.SendAsync("updateDealthyHallowCount",
              SD.DealthyHallowRace[SD.Cloak],
              SD.DealthyHallowRace[SD.Stone],
              SD.DealthyHallowRace[SD.Wand]);


            return Accepted();
        }

        public IActionResult Notification()
        {


            return View();
        }

        public IActionResult BasicChat()
        {


            return View();
        }
        //public IActionResult Chat()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    ChatVM chatVm = new ChatVM()
        //    {
        //        Rooms = _context.ChatRoom.ToList(),
        //        MaxRoomAllowed = 4,
        //        UserId = userId,
        //    };
        //    return View(chatVm);
        //}




    }
}
