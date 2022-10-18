using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class AdvertismentController : Controller
    {
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public AdvertismentController(AdvertismentService AdvertismentService,ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbAdvertisements ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.AdvertisementId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.AdvertisementImage = ImageName;
                    }
                }


                advertismentService.Add(ITEM);


            }
            else
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.AdvertisementImage = ImageName;
                    }
                }


                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                advertismentService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbAdvertisements oldItem = ctx.Advertisementss.Where(a => a.AdvertisementId == id).FirstOrDefault();

            advertismentService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbAdvertisements oldItem = ctx.Advertisementss.Where(a => a.AdvertisementId == id).FirstOrDefault();
            
           
            return View(oldItem);
        }
    }
}
