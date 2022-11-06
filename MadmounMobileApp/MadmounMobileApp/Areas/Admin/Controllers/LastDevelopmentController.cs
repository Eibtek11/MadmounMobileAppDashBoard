using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LastDevelopmentController : Controller
    {
        LastDevelopmentService lastDevelopmentService;
        AdviceService adviceService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public LastDevelopmentController(LastDevelopmentService LLastDevelopmentService,AdviceService AdviceService, AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            adviceService = AdviceService;
            lastDevelopmentService = LLastDevelopmentService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.lstAdvices = adviceService.getAll();
            model.LstLastDevelopments = lastDevelopmentService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbLastDevelopments ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.LastDevelopmentId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.LastDevelopmentImage = ImageName;
                    }
                }


                lastDevelopmentService.Add(ITEM);


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
                        ITEM.LastDevelopmentImage = ImageName;
                    }
                }


                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                lastDevelopmentService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.lstAdvices = adviceService.getAll();
            model.LstLastDevelopments = lastDevelopmentService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbLastDevelopments oldItem = ctx.TbLastDevelopmentss.Where(a => a.LastDevelopmentId == id).FirstOrDefault();

            lastDevelopmentService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = srviceCategoryService.getAll();
            model.lstAdvertisements = advertismentService.getAll();
            model.lstAdvices = adviceService.getAll();
            model.LstLastDevelopments = lastDevelopmentService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbLastDevelopments oldItem = ctx.TbLastDevelopmentss.Where(a => a.LastDevelopmentId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
