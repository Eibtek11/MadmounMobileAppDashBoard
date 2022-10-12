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

    public class ComplainsController : Controller
    {
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ComplainsController(ComplainService complainService,CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
        }
        
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbComplain ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ComplainId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                ComplainService.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                ComplainService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbComplain oldItem = ctx.TbComplains.Where(a => a.ComplainId == id).FirstOrDefault();

            ComplainService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbComplain oldItem = ctx.TbComplains.Where(a => a.ComplainId == id).FirstOrDefault();
            
            ViewBag.cities = cityService.getAll();
            return View(oldItem);
        }
    }
}
