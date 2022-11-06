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
    [Authorize(Roles = "Admin")]
    public class ServiceCategoryController : Controller
    {
        ServiceCategoryService serviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServiceCategoryController(ServiceCategoryService ServiceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            serviceCategoryService = ServiceCategoryService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = serviceCategoryService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbServiceCategory ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ServiceCategoryId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.CreatedBy = ImageName;
                    }
                }

                serviceCategoryService.Add(ITEM);


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
                        ITEM.CreatedBy = ImageName;
                    }
                }

                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                serviceCategoryService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = serviceCategoryService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbServiceCategory oldItem = ctx.TbServiceCategories.Where(a => a.ServiceCategoryId == id).FirstOrDefault();

            serviceCategoryService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = serviceCategoryService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbServiceCategory oldItem = ctx.TbServiceCategories.Where(a => a.ServiceCategoryId == id).FirstOrDefault();
           
            ViewBag.services = ctx.TbServiceCategories.ToList();
            return View(oldItem);
        }
    }
}
