using BL;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        LogInHistoryService logInHistoryService;
        SrrepService srrepService;
        SrOffService srOffService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public HomeController(LogInHistoryService LogInHistoryService,UserManager<ApplicationUser> usermanager ,SrrepService SrrepService,SrOffService SrOffService,AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            srOffService = SrOffService;
            srrepService = SrrepService;
             Usermanager = usermanager;
            logInHistoryService = LogInHistoryService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
           

            ViewBag.lstUsers = Usermanager.Users.Where(a => a.state == 0).Count();
            ViewBag.lstSrRepService = Usermanager.Users.Where(a => a.state == 1).Count();
            ViewBag.lstSrOffServiceS = Usermanager.Users.Where(a => a.state == 2).Count();
            model.lstCities = cityService.getAll();
            ViewBag.lstCities = model.lstCities.Count();
            model.lstAreas = areaService.getAll();
            ViewBag.Areas = model.lstAreas.Count();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            ViewBag.lstServices = model.lstServices.Count();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            ViewBag.lstServicecATEGORIES = model.lstServicecATEGORIES.Count();
            var activeDays = (from t in ctx.TbLoginHistories.Where(A => A.CreatedDate >= DateTime.Now.AddDays(-1)).ToList()
                                group t by t.Id into myVar
                                select new
                                {
                                    k = myVar.Key,
                                    c = myVar.Count()
                                });

            ViewBag.lstLogInHistoriesDays = activeDays.Count();
            var activeWeeks = (from t in ctx.TbLoginHistories.Where(A => A.CreatedDate >= DateTime.Now.AddDays(-7)).ToList()
                                group t by t.Id into myVar
                                select new
                                {
                                    k = myVar.Key,
                                    c = myVar.Count()
                                });

            ViewBag.lstLogInHistoriesWeeks = activeWeeks.Count();
            var activeMonths = (from t in ctx.TbLoginHistories.Where(A => A.CreatedDate >= DateTime.Now.AddDays(-30)).ToList()
                    group t by t.Id into myVar
                 select new
                 {
                     k = myVar.Key,
                     c = myVar.Count()
                 });
            
            ViewBag.lstLogInHistoriesMonths = activeMonths.Count();
            model.lstAdvertisements = advertismentService.getAll();
            return View(model);
        }
    }
}
