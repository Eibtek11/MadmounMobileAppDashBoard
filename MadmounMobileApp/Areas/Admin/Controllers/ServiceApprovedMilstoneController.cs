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
   
    public class ServiceApprovedMilstoneController : Controller
    {
        ServiceService srRecords;
        IGetServiceApprovedMillestone getServiceApprovedMillestone;
        ServiceService serviceService;
        ServiceApprovedMilstoneService srAppMil;
        ServiceApprovedImagesService srAppImage;
        ServicesApprovedService sr;
        ServicesRequiredService sq;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ServiceApprovedMilstoneController(ServiceService SrRecords, UserManager<ApplicationUser> usermanager, IGetServiceApprovedMillestone GetServiceApprovedMillestone,ServiceService ServiceService, ServiceApprovedMilstoneService SrAppMil,ServiceApprovedImagesService SrAppImage, ServicesApprovedService SR, ServicesRequiredService SQ, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            sr = SR;
            sq = SQ;
            srAppImage = SrAppImage;
            srAppMil = SrAppMil;
            serviceService = ServiceService;
            getServiceApprovedMillestone = GetServiceApprovedMillestone;
            Usermanager = usermanager;
            srRecords = SrRecords;

        }
        [Authorize(Roles = "Admin,Account")]
        public IActionResult Index(string Id, string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = srRecords.getAll();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstServiceApprovedImageS = srAppImage.getAll();
            model.lstServiceApprovedMilstone = srAppMil.getAll();
            model.LstVwMillestone = ctx.VwMillestones.ToList();
            ViewBag.cities2 = ctx.TbCities.ToList();
            ViewBag.cities = serviceService.getAll();
            model.LstGetServicesApproedMillestone = getServiceApprovedMillestone.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (DateOne != null && DateTwo != null && Id != null)
            {
                model.LstGetServicesApproedMillestone = getServiceApprovedMillestone.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo)).Where(a => a.ServiceId == Guid.Parse(Id));
            }
            model.lstUsers = Usermanager.Users.ToList();
            return View(model);


        }



        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(TbServiceApprovedMilstone ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ServiceApprovedMilstoneId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                srAppMil.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;
                
                srAppMil.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstServiceApprovedImageS = srAppImage.getAll();
            model.lstServiceApprovedMilstone = srAppMil.getAll();
            model.LstVwMillestone = ctx.VwMillestones.ToList();
            model.lstServices = srRecords.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {

            TbServiceApprovedMilstone oldItem = ctx.TbServiceApprovedMilstones.Where(a => a.ServiceApprovedMilstoneId == id).FirstOrDefault();

            srAppMil.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstServiceApprovedImageS = srAppImage.getAll();
            model.lstServiceApprovedMilstone = srAppMil.getAll();
            model.LstVwMillestone = ctx.VwMillestones.ToList();
            model.lstServices = srRecords.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin")]
        public IActionResult Form(Guid? id)
        {
            TbServiceApprovedMilstone oldItem = ctx.TbServiceApprovedMilstones.Where(a => a.ServiceApprovedMilstoneId == id).FirstOrDefault();

            ViewBag.cities = cityService.getAll();
            return View(oldItem);
        }
    }
}
