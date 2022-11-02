using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesOffersController : Controller
    {
        ServicesOfferService servicesOfferService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ServicesOffersController(ServicesOfferService ServicesOfferService,UserManager<ApplicationUser> usermanager, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            Usermanager = usermanager;
            servicesOfferService = ServicesOfferService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.LstServicesOffers = servicesOfferService.getAll();
            return View(model);


        }
       



        public async Task<IActionResult> Save(TbServicesOffers ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ServicesOffersId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                servicesOfferService.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                servicesOfferService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.LstServicesOffers = servicesOfferService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbServicesOffers oldItem = ctx.TbServicesOfferss.Where(a => a.ServicesOffersId == id).FirstOrDefault();

            servicesOfferService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.LstServicesOffers = servicesOfferService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbServicesOffers oldItem = ctx.TbServicesOfferss.Where(a => a.ServicesOffersId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
