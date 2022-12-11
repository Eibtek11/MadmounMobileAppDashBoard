using BL;
using BL.Models;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginHistoryController : Controller
    {
        IGetLogInHistory getLogInHistory;
        LogInHistoryService logInHistoryService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public LoginHistoryController(IGetLogInHistory GetLogInHistory,UserManager<ApplicationUser> usermanager, LogInHistoryService LogInHistoryService,ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            logInHistoryService = LogInHistoryService;
            Usermanager = usermanager;
            getLogInHistory = GetLogInHistory;
        }
        public IActionResult Index(string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstLogInHistories = logInHistoryService.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            model.LstGetLogInHistory = getLogInHistory.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (DateOne != null && DateTwo != null)
            {
                model.LstGetLogInHistory = getLogInHistory.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo));
            }
            var servicesNoRequested = (from t in model.LstGetLogInHistory
                                       group t by t.Id into myVar
                                       select new
                                       {
                                           k = myVar.Key,
                                           c = myVar.Count()
                                       });

            List<GetActiveUsersNo> lstgetServicesNos = new List<GetActiveUsersNo>();
            foreach (var i in servicesNoRequested)
            {
                GetActiveUsersNo element = new GetActiveUsersNo();
                element.Id = Guid.Parse(i.k);
                element.count = i.c;
                lstgetServicesNos.Add(element);

            }
            model.LstGetActiveUsersNo = lstgetServicesNos;
           
            return View(model);


        }




        public async Task<IActionResult> Save(TbLoginHistory ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.LogInId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                logInHistoryService.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                logInHistoryService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstLogInHistories = logInHistoryService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbLoginHistory oldItem = ctx.TbLoginHistories.Where(a => a.LogInId == id).FirstOrDefault();

            logInHistoryService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstLogInHistories = logInHistoryService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbLoginHistory oldItem = ctx.TbLoginHistories.Where(a => a.LogInId == id).FirstOrDefault();

            ViewBag.cities = cityService.getAll();
            return View(oldItem);
        }
    }
}
