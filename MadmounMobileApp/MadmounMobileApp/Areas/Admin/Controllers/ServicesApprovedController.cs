using BL;
using BL.Models;
using Domains;
using MadmounMobileApp.Models;
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
    public class ServicesApprovedController : Controller
    {
        IGetServiceApproved getServicesApproed;
        ServiceService srRecords;
        ServicesApprovedService sr;
        ServicesRequiredService sq;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ServicesApprovedController(IGetServiceApproved GetServicesApproed,UserManager<ApplicationUser> usermanager ,ServiceService SrRecords,ServicesApprovedService SR,ServicesRequiredService SQ, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            sr = SR;
            sq = SQ;
            srRecords = SrRecords;
            Usermanager = usermanager;
            getServicesApproed = GetServicesApproed;
        }
        public IActionResult Index( string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = srRecords.getAll();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.LstGetServicesApproed = getServicesApproed.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if ( DateOne != null && DateTwo != null)
            {
                model.LstGetServicesApproed = getServicesApproed.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo));
            }
            model.lstUsers = Usermanager.Users.ToList();
            return View(model);


        }




        public async Task<IActionResult> Save(TbServicesApproved ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ServiceApprovedId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                sr.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                sr.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstServices = srRecords.getAll();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            model.lstServicesApprovedS = sr.getAll();
            model.LstGetServicesApproed = getServicesApproed.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbServicesApproved oldItem = ctx.TbServicesApproveds.Where(a => a.ServiceApprovedId == id).FirstOrDefault();

            sr.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstServices = srRecords.getAll();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            model.lstServicesApprovedS = sr.getAll();
            model.LstGetServicesApproed = getServicesApproed.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);

            return View("Index", model);



        }

        public IActionResult Final(Guid id)
        {

            TbServicesApproved oldItem = ctx.TbServicesApproveds.Where(a => a.ServiceApprovedId == id).FirstOrDefault();
            oldItem.ServiceSyntax = "Finished";
            sr.Edit(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstServices = srRecords.getAll();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            model.lstServicesApprovedS = sr.getAll();
            model.LstGetServicesApproed = getServicesApproed.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbServicesApproved oldItem = ctx.TbServicesApproveds.Where(a => a.ServiceApprovedId == id).FirstOrDefault();

            ViewBag.cities = cityService.getAll();
            return View(oldItem);
        }
    }
}
