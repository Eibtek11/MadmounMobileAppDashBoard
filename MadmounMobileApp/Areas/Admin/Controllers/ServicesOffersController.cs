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
using BL.Models;
using Microsoft.AspNetCore.Authorization;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    public class ServicesOffersController : Controller
    {

        IGetServiceOffers getServiceOffers;
        ServicesOfferService servicesOfferService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ServicesOffersController(IGetServiceOffers GetServiceOffers, ServicesOfferService ServicesOfferService,UserManager<ApplicationUser> usermanager, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            Usermanager = usermanager;
            servicesOfferService = ServicesOfferService;
            getServiceOffers = GetServiceOffers;
        }
        [Authorize(Roles = "Admin,عروض اسعار / حالة عرض السعر مقبولة او مرفوضة")]
        public IActionResult Index(string id,string DateOne, string DateTwo)
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.LstServicesOffers = servicesOfferService.getAll();
            model.LstGetServicesOffers = getServiceOffers.GetAll(DateTime.Parse("2020-11-05 22:17:26.510"), DateTime.Now);
            if (DateOne != null && DateTwo != null)
            {
                model.LstGetServicesOffers = getServiceOffers.GetAll(DateTime.Parse(DateOne), DateTime.Parse(DateTwo)).Where(a=> a.Notes == id);
            }
            return View(model);


        }



        [Authorize(Roles = "Admin")]
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




        [Authorize(Roles = "Admin")]
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



        [Authorize(Roles = "Admin")]
        public IActionResult Form(Guid? id)
        {
            TbServicesOffers oldItem = ctx.TbServicesOfferss.Where(a => a.ServicesOffersId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
