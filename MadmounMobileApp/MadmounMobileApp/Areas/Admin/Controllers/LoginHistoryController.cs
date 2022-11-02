using BL;
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
        LogInHistoryService logInHistoryService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public LoginHistoryController(UserManager<ApplicationUser> usermanager, LogInHistoryService LogInHistoryService,ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            logInHistoryService = LogInHistoryService;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstLogInHistories = logInHistoryService.getAll();
            model.lstUsers = Usermanager.Users.ToList();
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
