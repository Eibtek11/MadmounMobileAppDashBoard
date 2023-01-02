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
   
    public class SrRepCityController : Controller
    {
        SrrepCityService srrepCityService;
        SrrepService srrepService;
        ServiceCategoryService fl;
        ServiceService serviceService;
        SrOffService srOffService;
        ServicesApprovedService sr;
        ServicesRequiredService sq;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public SrRepCityController(SrrepCityService SrrepCityService,SrrepService SrrepService, UserManager<ApplicationUser> usermanager, ServiceCategoryService FL, ServiceService ServiceService, SrOffService SrOffService, ServicesApprovedService SR, ServicesRequiredService SQ, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            sr = SR;
            sq = SQ;
            srOffService = SrOffService;
            serviceService = ServiceService;
            fl = FL;
            Usermanager = usermanager;
            srrepService = SrrepService;
            srrepCityService = SrrepCityService;
        }
        [Authorize(Roles = "Admin , مدن ممثلي الخدمات")]
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstSrOffServiceS = srOffService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = fl.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            model.lstSrRepService = srrepService.getAll();
            model.lstSrRepCity = srrepCityService.getAll();
            return View(model);
        }

        [Authorize(Roles = "Admin , اضافة مدن ممثلي الخدمات")]
        public async Task<IActionResult> Save(string ahmed, TbSrRepCity ITEM, int id, List<IFormFile> files, string idd, string serviceid, string servicoffeid)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.SrRepCityId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                srrepCityService.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;
                ITEM.Id = ahmed;

                srrepCityService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstSrOffServiceS = srOffService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = fl.getAll();
            model.lstSrRepService = srrepService.getAll();
            model.lstSrRepCity = srrepCityService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin , حذف مدن  ممثلي الخدمات")]
        public IActionResult Delete(Guid id)
        {

            TbSrRepCity oldItem = ctx.TbSrRepCities.Where(a => a.SrRepCityId == id).FirstOrDefault();

            srrepCityService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstSrOffServiceS = srOffService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = fl.getAll();
            model.lstSrRepService = srrepService.getAll();
            model.lstSrRepCity = srrepCityService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbSrRepCity oldItem = ctx.TbSrRepCities.Where(a => a.SrRepCityId == id).FirstOrDefault();

            ViewBag.services = cityService.getAll();
            ViewBag.servicesCATEGORY = areaService.getAll();
            return View(oldItem);
        }

        public IActionResult Form2(Guid? id, string idd)
        {
            TbSrRepCity oldItem = ctx.TbSrRepCities.Where(a => a.SrRepCityId == id).FirstOrDefault();
            oldItem.Id = idd;
            ViewBag.id = idd;

            ViewBag.serviceid = oldItem.CityId;
            ViewBag.serviceoffid = oldItem.SrRepCityId;
            ViewBag.services = cityService.getAll();
            ViewBag.servicesCATEGORY = areaService.getAll();
            return View(oldItem);
        }
    }
}
