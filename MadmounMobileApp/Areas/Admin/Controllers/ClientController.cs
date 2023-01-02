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
    
    public class ClientController : Controller
    {
        CleintService cleintService;
        CityService cityService;
        MadmounDbContext ctx;
        public ClientController(CleintService CleintService,CityService Cityservice, MadmounDbContext context)
        {
            cityService = Cityservice;
            ctx = context;
            cleintService = CleintService;

        }

        [Authorize(Roles = "Admin,العملاء")]
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstCities = cityService.getAll();
            model.lstClients = cleintService.getAll();
            return View(model);


        }



        [Authorize(Roles = "Admin,اضافة العملاء ")]
        public async Task<IActionResult> Save(TbClients ITEM, int id, List<IFormFile> files, List<IFormFile> filess)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.CityId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".mp4";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.ClientVideo = ImageName;
                    }
                }
                foreach (var file in filess)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.ClientLogo = ImageName;
                    }
                }




                cleintService.Add(ITEM);


            }
            else
            {

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".mp4";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.ClientVideo = ImageName;
                    }
                }
                foreach (var file in filess)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.ClientLogo = ImageName;
                    }
                }

                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                cleintService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstCities = cityService.getAll();
            model.lstClients = cleintService.getAll();


            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف العملاء ")]
        public IActionResult Delete(Guid id)
        {

            TbClients oldItem = ctx.TbClients.Where(a => a.ClientId == id).FirstOrDefault();

            cleintService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstCities = cityService.getAll();
            model.lstClients = cleintService.getAll();


            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbClients oldItem = ctx.TbClients.Where(a => a.ClientId == id).FirstOrDefault();
          

            return View(oldItem);
        }
    }
}
