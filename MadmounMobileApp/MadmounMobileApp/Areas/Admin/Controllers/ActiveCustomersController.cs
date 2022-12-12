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
    [Authorize(Roles = "Admin")]
    public class ActiveCustomersController : Controller
    {
        IGetLogInHistory getLogInHistory;
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
        public ActiveCustomersController(IGetLogInHistory GetLogInHistory, ServicesRequiredService ServicesRequiredService, SrrepCityService SrrepCityService, SroffCityService SroffCityService, ServiceApprovedMilstoneService ServiceApprovedMilstoneService, IGetChat GetChat, LogInHistoryService LogInHistoryService, UserManager<ApplicationUser> usermanager, SrrepService SrrepService, SrOffService SrOffService, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
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

            getLogInHistory = GetLogInHistory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowData()
        {
            return View();
        }
        [HttpPost]
        public List<object> GetSalesData(string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            
            model.lstLogInHistories = logInHistoryService.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            model.LstGetLogInHistory = getLogInHistory.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (DateOne != null && DateTwo != null)
            {
                model.LstGetLogInHistory = getLogInHistory.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo));
            }
           
            var servicesNoRequested = (from t in model.LstGetLogInHistory
                                       group t by t.UpdatedBy into myVar
                                       select new
                                       {
                                           k = myVar.Key,
                                           c = myVar.Count()
                                       });

            List<GetActiveUsersNo> lstgetServicesNos = new List<GetActiveUsersNo>();
            foreach (var i in servicesNoRequested)
            {
                GetActiveUsersNo element = new GetActiveUsersNo();
                element.Id = i.k;
                element.count = i.c;
                lstgetServicesNos.Add(element);

            }
            model.LstGetActiveUsersNo = lstgetServicesNos;
            List<object> data = new List<object>();
            List<string> labels = model.LstGetActiveUsersNo.Select(p => p.Id).ToList();
            data.Add(labels);
            List<int> SalesNumber = model.LstGetActiveUsersNo.Select(p => p.count).ToList();
            data.Add(SalesNumber);
            return data;
        }
    }
}
