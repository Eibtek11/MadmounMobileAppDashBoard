using BL;
using Domains;
using MadmounMobileApp.Models;
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
    public class ServiceApprovedImagesController : Controller
    {
        ServiceApprovedImagesService srAppImage;
        ServicesApprovedService sr;
        ServicesRequiredService sq;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServiceApprovedImagesController(ServiceApprovedImagesService SrAppImage,ServicesApprovedService SR, ServicesRequiredService SQ, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            sr = SR;
            sq = SQ;
            srAppImage = SrAppImage;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstServiceApprovedImageS = srAppImage.getAll();
       
            return View(model);


        }




        public async Task<IActionResult> Save(TbServiceApprovedImage ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ServiceApprovedImageId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.ImagePath = ImageName;
                    }
                }

                srAppImage.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;
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
                        ITEM.ImagePath = ImageName;
                    }
                }
                srAppImage.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstServiceApprovedImageS = srAppImage.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbServiceApprovedImage oldItem = ctx.TbServiceApprovedImages.Where(a => a.ServiceApprovedImageId == id).FirstOrDefault();

            srAppImage.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstServiceApprovedImageS = srAppImage.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbServiceApprovedImage oldItem = ctx.TbServiceApprovedImages.Where(a => a.ServiceApprovedImageId == id).FirstOrDefault();

            ViewBag.cities = cityService.getAll();
            return View(oldItem);
        }
    }
}
