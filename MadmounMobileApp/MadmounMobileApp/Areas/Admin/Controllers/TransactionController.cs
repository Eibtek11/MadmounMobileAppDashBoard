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
    public class TransactionController : Controller
    {
        TransactionService transactionService;
        ServiceService srRecords;
        ServicesApprovedService sr;
        ServicesRequiredService sq;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public TransactionController(TransactionService Transactionsservice,UserManager<ApplicationUser> usermanager, ServiceService SrRecords, ServicesApprovedService SR, ServicesRequiredService SQ, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            sr = SR;
            sq = SQ;
            srRecords = SrRecords;
            Usermanager = usermanager;
            transactionService = Transactionsservice;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = srRecords.getAll();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.lstUsers = Usermanager.Users.ToList();
            model.LstTransactionS = transactionService.getAll();
            return View(model);


        }




        public async Task<IActionResult> Save(TbTransaction ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.TransactionId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {




                transactionService.Add(ITEM);


            }
            else
            {



                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                transactionService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.LstTransactionS = transactionService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbTransaction oldItem = ctx.TbTransactions.Where(a => a.TransactionId == id).FirstOrDefault();

            transactionService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            model.lstCities = cityService.getAll();
            model.lstComplains = ComplainService.getAll();
            model.lstServicesRequireds = sq.getAll();
            model.lstServicesApprovedS = sr.getAll();
            model.LstTransactionS = transactionService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbServiceApprovedMilstone oTbServiceApprovedMilstone = ctx.TbServiceApprovedMilstones.Where(a => a.ServiceApprovedMilstoneId == id).FirstOrDefault();
            TbServicesApproved oldItem = ctx.TbServicesApproveds.Where(a => a.ServiceApprovedId == oTbServiceApprovedMilstone.ServiceApprovedId).FirstOrDefault();
            TbTransaction oTbTransaction = new TbTransaction();
            oTbTransaction.SrOffId = oldItem.SrOffId;
            oTbTransaction.SrReqId = oldItem.SrReqId;
            oTbTransaction.SrRepId = oldItem.SrRepId;
            oTbTransaction.AreaId = oldItem.AreaId;
            oTbTransaction.CityId = oldItem.CityId;
            oTbTransaction.ServicesRequiredId = Guid.Parse(oldItem.CreatedBy);
            oTbTransaction.ServiceId = oldItem.ServiceId;
            oTbTransaction.ServiceApprovedMilstoneId = oTbServiceApprovedMilstone.ServiceApprovedMilstoneId;
            ViewBag.cities = cityService.getAll();
            return View(oTbTransaction);
        }
    }
}
