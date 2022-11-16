using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MadmounMobileApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServcesFinishedController : Controller
    {
        ServicesFinishedService servicesFinished;
        IGetServiceApproved getServicesApproed;
        ServiceService srRecords;
        ServicesApprovedService sr;
        ServicesRequiredService sq;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public ServcesFinishedController(ServicesFinishedService ServicesFinished,IGetServiceApproved GetServicesApproed, UserManager<ApplicationUser> usermanager, ServiceService SrRecords, ServicesApprovedService SR, ServicesRequiredService SQ, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            sr = SR;
            sq = SQ;
            srRecords = SrRecords;
            Usermanager = usermanager;
            getServicesApproed = GetServicesApproed;
            servicesFinished = ServicesFinished;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = srRecords.getAll();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.LstTbServicesFinished = servicesFinished.getAll();
          
            model.lstUsers = Usermanager.Users.ToList();
            return View(model);
        }
     




        public async Task<IActionResult> Save(TbServicesFinished ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ServiceFinishedId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                servicesFinished.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                servicesFinished.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstServices = srRecords.getAll();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            model.LstTbServicesFinished = servicesFinished.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbServicesFinished oldItem = ctx.TbServicesFinisheds.Where(a => a.ServiceFinishedId == id).FirstOrDefault();

            servicesFinished.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstServices = srRecords.getAll();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            model.LstTbServicesFinished = servicesFinished.getAll();

            return View("Index", model);



        }

      




        public IActionResult Form(Guid? id)
        {
            TbServicesFinished oldItem = ctx.TbServicesFinisheds.Where(a => a.ServiceFinishedId == id).FirstOrDefault();

            ViewBag.cities = cityService.getAll();
            return View(oldItem);
        }
    }
}
