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
    public class ServicesRequiredController : Controller
    {
        ServiceService srRecords;
        ServicesApprovedService sr;
        ServicesRequiredService sq;
        ServicesApprovedService servicesApprovedService;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ServicesRequiredController(UserManager<ApplicationUser> usermanager, ServiceService SrRecords, ServicesApprovedService SR, ServicesRequiredService SQ,ServicesApprovedService ServicesApprovedService,ServicesRequiredService ServicesRequiredService,ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            servicesApprovedService = ServicesApprovedService;
            sr = SR;
            sq = SQ;
            srRecords = SrRecords;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = srRecords.getAll();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
          
            model.lstServicesApprovedS = sr.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            return View(model);


        }




        public async Task<IActionResult> Save(TbServicesRequired ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ServicesRequiredId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                servicesRequiredService.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                servicesRequiredService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = servicesRequiredService.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbServicesRequired oldItem = ctx.TbServicesRequireds.Where(a => a.ServicesRequiredId == id).FirstOrDefault();

            servicesRequiredService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = servicesRequiredService.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbServicesRequired oldItem = ctx.TbServicesRequireds.Where(a => a.ServicesRequiredId == id).FirstOrDefault();

            ViewBag.cities = cityService.getAll();
            return View(oldItem);
        }
    }
}
