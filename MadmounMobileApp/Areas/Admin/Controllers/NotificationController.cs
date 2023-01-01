using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Administeration")]
    public class NotificationController : Controller
    {
        NotificationService notificationService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public NotificationController(UserManager<ApplicationUser> usermanager, NotificationService NotificationService,ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            notificationService = NotificationService;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll().OrderByDescending(a => a.CreatedDate);
            model.LstNotifications = notificationService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbNotification ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.NotificationId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                notificationService.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                notificationService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.LstNotifications = notificationService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbNotification oldItem = ctx.TbNotifications.Where(a => a.NotificationId == id).FirstOrDefault();

            notificationService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.LstNotifications = notificationService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbNotification oldItem = ctx.TbNotifications.Where(a => a.NotificationId == id).FirstOrDefault();

            ViewBag.cities = Usermanager.Users.ToList();
            return View(oldItem);
        }
    }
}
