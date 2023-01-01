using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Administeration")]
    public class AreaController : Controller
    {
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public AreaController(CityService CityService,AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbArea ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.AreaId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                areaService.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                areaService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();

            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbArea oldItem = ctx.TbAreas.Where(a => a.AreaId == id).FirstOrDefault();

            areaService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();

            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbArea oldItem = ctx.TbAreas.Where(a => a.AreaId == id).FirstOrDefault();
            oldItem = ctx.TbAreas.Where(a => a.AreaId == id).FirstOrDefault();
            ViewBag.cities = cityService.getAll();
            return View(oldItem);
        }
    }
}
