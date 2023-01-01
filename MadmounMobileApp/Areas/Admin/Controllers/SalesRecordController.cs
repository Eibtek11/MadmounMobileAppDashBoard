using BL;
using BL.Models;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class SalesRecordController : Controller
    {
        ServicesRequiredService servicesRequiredService;
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
        public SalesRecordController(ServicesRequiredService ServicesRequiredService, SrrepCityService SrrepCityService, SroffCityService SroffCityService, ServiceApprovedMilstoneService ServiceApprovedMilstoneService, IGetChat GetChat, LogInHistoryService LogInHistoryService, UserManager<ApplicationUser> usermanager, SrrepService SrrepService, SrOffService SrOffService, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
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
            servicesRequiredService = ServicesRequiredService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Account")]
        public IActionResult ShowData()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Account")]
        [HttpPost]
        public List<object> GetSalesData(string DateOne, string DateTwo) 
        {
            HomePageModel model = new HomePageModel();
            model.lstUsers = Usermanager.Users.Where(a => a.StateName == "مقدم خدمة").ToList();
            if (DateOne != null && DateTwo != null)
            {
                model.lstUsers = model.lstUsers = Usermanager.Users.Where(a => a.StateName == "مقدم خدمة").ToList().Where(a => a.CreatedDate >= DateTime.Parse(DateOne) && a.CreatedDate <= DateTime.Parse(DateTwo));
            }
            var servicesNoRequested = (from t in model.lstUsers
                                       group t by t.CityName into myVar
                                       select new
                                       {
                                           k = myVar.Key,
                                           c = myVar.Count()
                                       });

            List<GetNoOffByCity> lstgetServicesNos = new List<GetNoOffByCity>();
            foreach (var i in servicesNoRequested)
            {
                GetNoOffByCity element = new GetNoOffByCity();
                element.CityName = i.k;
                element.count = i.c;
                lstgetServicesNos.Add(element);

            }
            model.LstGetNoOffByCity = lstgetServicesNos;
            List <object> data = new List<object>();
            List<string> labels = model.LstGetNoOffByCity.Select(p => p.CityName).ToList();
            data.Add(labels);
            List<int> SalesNumber = model.LstGetNoOffByCity.Select(p => p.count).ToList();
            data.Add(SalesNumber);
            return data;
        }
    }
}
