using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SRepServiceController : Controller
    {
        SrrepService srrepService;
        ServiceCategoryService fl;
        ServiceService serviceService;
        SrOffService srOffService;
        ServicesApprovedService sr;
        ServicesRequiredService sq;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public SRepServiceController(SrrepService SrrepService,UserManager<ApplicationUser> usermanager, ServiceCategoryService FL, ServiceService ServiceService, SrOffService SrOffService, ServicesApprovedService SR, ServicesRequiredService SQ, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            sr = SR;
            sq = SQ;
            srOffService = SrOffService;
            serviceService = ServiceService;
            fl = FL;
            Usermanager = usermanager;
            srrepService = SrrepService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstSrOffServiceS = srOffService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = fl.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            model.lstSrRepService = srrepService.getAll();
            return View(model);
        }


        public async Task<IActionResult> Save(string ahmed, TbSrRepService ITEM, int id, List<IFormFile> files, string idd, string serviceid, string servicoffeid)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.SrRepServiceId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                srrepService.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;
                ITEM.Id = ahmed;

                srrepService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstSrOffServiceS = srOffService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = fl.getAll();
            model.lstSrRepService = srrepService.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbSrRepService oldItem = ctx.TbSrRepServices.Where(a => a.SrRepServiceId == id).FirstOrDefault();

            srrepService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstSrOffServiceS = srOffService.getAll();
            model.lstServices = serviceService.getAll();
            model.lstServicecATEGORIES = fl.getAll();
            model.lstSrRepService = srrepService.getAll();
            return View("Index", model);



        }




        public async Task<IActionResult> FormAsync(Guid? id)
        {
            var user = await Usermanager.FindByIdAsync(id.ToString());
            user.ServiceName = "Approved";
            user.state = 1;
            ApplicationUser objFromDb = Usermanager.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            if (objFromDb == null)
            {
                return NotFound();
            }
            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is locked and will remain locked untill lockoutend time
                //clicking on this action will unlock them
                objFromDb.LockoutEnd = DateTime.Now;
                //TempData[SD.Success] = "User unlocked successfully.";
            }

            ctx.SaveChanges();
            var result = await Usermanager.UpdateAsync(user);
            TbSrRepService oldItem = ctx.TbSrRepServices.Where(a => a.SrRepServiceId == id).FirstOrDefault();

            ViewBag.services = serviceService.getAll();
            ViewBag.servicesCATEGORY = fl.getAll();
            return View(oldItem);
        }

        public IActionResult Form2(Guid? id, string idd)
        {
            TbSrRepService oldItem = ctx.TbSrRepServices.Where(a => a.SrRepServiceId == id).FirstOrDefault();
            oldItem.Id = idd;
            ViewBag.id = idd;

            ViewBag.serviceid = oldItem.ServiceId;
            ViewBag.serviceoffid = oldItem.SrRepServiceId;
            ViewBag.services = serviceService.getAll();
            ViewBag.servicesCATEGORY = fl.getAll();
            return View(oldItem);
        }
    }
}
