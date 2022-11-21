using BL;
using BL.Models;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        SrrepCityService srrepCityService;
        SroffCityService sroffCityService;
        ServiceApprovedMilstoneService serviceApprovedMilstoneService;
        IGetChat getChat;
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
        public HomeController(SrrepCityService SrrepCityService,SroffCityService SroffCityService,ServiceApprovedMilstoneService ServiceApprovedMilstoneService,IGetChat GetChat,LogInHistoryService LogInHistoryService,UserManager<ApplicationUser> usermanager ,SrrepService SrrepService,SrOffService SrOffService,AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
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
            getChat = GetChat;
            serviceApprovedMilstoneService = ServiceApprovedMilstoneService;
            sroffCityService = SroffCityService;
            srrepCityService = SrrepCityService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
           

            ViewBag.lstUsers = Usermanager.Users.Where(a => a.StateName == "طالب خدمة").Count();
            ViewBag.lstSrRepService = Usermanager.Users.Where(a => a.StateName == "ممثل خدمة").Count();
            ViewBag.lstSrOffServiceS = Usermanager.Users.Where(a => a.StateName == "مقدم خدمة").Count();
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
            ViewBag.cities = Usermanager.Users.Where(a => a.StateName == "مقدم خدمة").ToList();
            ViewBag.lstLogInHistoriesMonths = activeMonths.Count();
            model.lstAdvertisements = advertismentService.getAll();
           
            return View(model);
        }



        public IActionResult Payment(string Id , string DateOne , string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();

            ViewBag.cities = Usermanager.Users.Where(a => a.StateName == "مقدم خدمة").ToList();
            model.LstGetPayment = getChat.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (Id != null && DateOne != null && DateTwo != null)
            {
                model.LstGetPayment = getChat.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo)).Where(a => a.SrOffId == Id);
            }
            int count = model.LstGetPayment.Sum(a => int.Parse(a.CreatedBy));
            ViewBag.lstSrOffServiceS = count;
            return View(model);
        }
        public IActionResult Payment2(string Id, string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();

            ViewBag.cities = Usermanager.Users.Where(a => a.StateName == "ممثل خدمة").ToList();
            model.LstGetPayment = getChat.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (Id != null && DateOne != null && DateTwo != null)
            {
                model.LstGetPayment = getChat.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo)).Where(a => a.SrRepId == Id);
            }
            int count = model.LstGetPayment.Sum(a => int.Parse(a.CreatedBy));
            ViewBag.lstSrOffServiceS = count;

            return View(model);
        }
        public IActionResult Payment3(string Id, string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();

            ViewBag.cities = Usermanager.Users.Where(a => a.StateName == "طالب خدمة").ToList();
            model.LstGetPayment = getChat.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (Id != null && DateOne!=null && DateTwo!=null)
            {
                model.LstGetPayment = getChat.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo)).Where(a => a.SrReqId == Id);
            }
            int count = model.LstGetPayment.Sum(a => int.Parse(a.CreatedBy));
            ViewBag.lstSrOffServiceS = count;
            return View(model);
        }

        public IActionResult Payment4( string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();

            ViewBag.cities = Usermanager.Users.Where(a => a.StateName == "طالب خدمة").ToList();
            model.LstGetPayment = getChat.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if ( DateOne != null && DateTwo != null)
            {
                model.LstGetPayment = getChat.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo));
            }
            int count = model.LstGetPayment.Sum(a => int.Parse(a.CreatedBy));
            ViewBag.lstSrOffServiceS = count;
            return View(model);
        }

        public IActionResult Payment5(string Id, string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();

            ViewBag.cities = serviceService.getAll();
            model.LstGetPayment = getChat.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (DateOne != null && DateTwo != null)
            {
                model.LstGetPayment = getChat.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo)).Where(a => a.ServiceId == Guid.Parse(Id));
            }
            int count = model.LstGetPayment.Sum(a => int.Parse(a.CreatedBy));
            ViewBag.lstSrOffServiceS = count;
            return View(model);
        }


        public IActionResult Payment6()
        {
            HomePageModel model = new HomePageModel();
            var servicesNoRequested = (from t in ctx.TbServicesRequireds.Include(a => a.Service).ToList()
                                       group t by t.Service.ServiceName into myVar
                                       select new
                                       {
                                           k = myVar.Key,
                                           c = myVar.Count()
                                       });
            
            List<GetServicesNo> lstgetServicesNos = new List<GetServicesNo>();
            foreach (var i in servicesNoRequested)
            {
                GetServicesNo element = new GetServicesNo();
                element.ServiceName = i.k;
                element.count = i.c;
                lstgetServicesNos.Add(element);

            }
            model.LstGetServicesNo = lstgetServicesNos;
            return View(model);
        }



        public IActionResult Payment7(string Id)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();
            model.lstSrOffServiceS = srOffService.getAll();
            model.LstVwFilterOffs = ctx.VwFilterOffs.ToList();
            if (Id != null)
            {
                model.LstVwFilterOffs = ctx.VwFilterOffs.ToList().Where(a => a.ServiceId == Guid.Parse(Id));
                
            }
           
            ViewBag.cities = serviceService.getAll();
           
            return View(model);
        }


        public IActionResult Payment8(string Id)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();
            model.lstSrRepService = srrepService.getAll();
            model.LstVwFilterreps = ctx.VwFilterreps.ToList();
            if (Id != null)
            {
                model.LstVwFilterreps = ctx.VwFilterreps.ToList().Where(a => a.ServiceId == Guid.Parse(Id));
            }

            ViewBag.cities = serviceService.getAll();

            return View(model);
        }


        public IActionResult Payment9(string Id)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();
            model.lstSrOffCity = sroffCityService.getAll();
            if (Id != null)
            {
                model.lstSrOffCity = sroffCityService.getAll().Where(a => a.CityId == Guid.Parse(Id));
            }

            ViewBag.cities = cityService.getAll();

            return View(model);
        }



        public IActionResult Payment10(string Id)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll();
            model.lstCities = cityService.getAll();
            model.lstAreas = areaService.getAll();
            model.lstServiceApprovedMilstone = serviceApprovedMilstoneService.getAll();
            model.lstSrRepCity = srrepCityService.getAll();
            if (Id != null)
            {
                model.lstSrRepCity = srrepCityService.getAll().Where(a => a.CityId == Guid.Parse(Id));
            }

            ViewBag.cities = cityService.getAll();

            return View(model);
        }
    }
}
