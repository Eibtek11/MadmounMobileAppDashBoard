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
   
    public class ClientImageController : Controller
    {
        ClientImagesService clientImagesService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ClientImageController(ClientImagesService ClientImagesService,CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            clientImagesService = ClientImagesService;
        }
        [Authorize(Roles = "Admin,مراحل مشاريع العملاء")]
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstClientImages = clientImagesService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbClientImages ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ClientImageId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.ClientImage = ImageName;
                    }
                }




                clientImagesService.Add(ITEM);


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
                        ITEM.ClientImage = ImageName;
                    }
                }

                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                clientImagesService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstClientImages = clientImagesService.getAll();

            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbClientImages oldItem = ctx.TbClientImages.Where(a => a.ClientImageId == id).FirstOrDefault();

            clientImagesService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstClientImages = clientImagesService.getAll();

            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbClientImages oldItem = new TbClientImages();
            oldItem.ClientId = id;
            return View(oldItem);
        }


        public IActionResult Form2(Guid? id, Guid? idd)
        {
            TbClientImages oldItem = ctx.TbClientImages.Where(a => a.ClientImageId == id).FirstOrDefault();
            oldItem.ClientId = idd;
            ViewBag.id = idd;

         
            return View(oldItem);
        }
    }
}
