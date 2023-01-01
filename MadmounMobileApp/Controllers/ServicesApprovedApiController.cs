using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesApprovedApiController : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        ServicesApprovedService servicesApprovedService;
        ServicesOfferService servicesOfferService;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesApprovedApiController(UserManager<ApplicationUser> usermanager, ServicesApprovedService ServicesApprovedService,ServicesOfferService ServicesOfferService, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            servicesOfferService = ServicesOfferService;
            servicesApprovedService = ServicesApprovedService;
            Usermanager = usermanager;
        }
        // GET: api/<ServicesApprovedApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServicesApprovedApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServicesApproved> Get(string id)
        {
            return ctx.TbServicesApproveds.Where(a => a.SrRepId == id).Include(a=> a.Service).ToList();
        }

        // POST api/<ServicesApprovedApiController>
        [HttpPost("approveService")]
        public TbServicesApproved Post([FromForm] ServicesApproveViewPageModel services)
        {
            TbServicesOffers oTbServicesOffers = ctx.TbServicesOfferss.Where(a => a.ServicesOffersId == Guid.Parse(services.CreatedBy)).FirstOrDefault();
            oTbServicesOffers.Notes = "موافقة";
            servicesOfferService.Edit(oTbServicesOffers);
            TbServicesRequired oTbServicesRequired = ctx.TbServicesRequireds.Where(a => a.ServicesRequiredId == oTbServicesOffers.ServicesRequiredId).FirstOrDefault();
            oTbServicesRequired.ApprovalStatus = "Approved";
            servicesRequiredService.Edit(oTbServicesRequired);
            TbServicesApproved oTbServicesApproved = new TbServicesApproved();
            oTbServicesApproved.SrRepId = services.SrRepId;
            oTbServicesApproved.SrReqId = services.SrReqId;
            oTbServicesApproved.SrOffId = services.SrOffId;
            oTbServicesApproved.CreatedBy =  oTbServicesOffers.ServicesRequiredId.ToString();
            oTbServicesApproved.Notes = services.Notes;
            oTbServicesApproved.ServiceId = services.ServiceId;
            oTbServicesApproved.CityId = services.CityId;
            oTbServicesApproved.AreaId = services.AreaId;
            oTbServicesApproved.CreatedDate = DateTime.Now;
            oTbServicesApproved.UpdatedBy = Usermanager.Users.Where(a => a.Id == oTbServicesRequired.SrReqId).FirstOrDefault().Email;
            oTbServicesApproved.ContractPdf = oTbServicesRequired.CreatedBy;
            oTbServicesApproved.SrApprovedDescription = oTbServicesRequired.RyadahOrNot;
            var result = servicesApprovedService.Add(oTbServicesApproved);

          
            return oTbServicesApproved;
        }




        [HttpPost("underDoing")]
        public IEnumerable<TbServicesApproved> underDoing([FromForm] ServicesApproveViewPageModel services)
        {


            return ctx.TbServicesApproveds.Include(a => a.Service).Include(a => a.TbServiceApprovedMilstones).ToList().Where(a => a.SrRepId == services.SrRepId);
        }
        [HttpPost("underDoingrayadah")]
        public IEnumerable<TbServicesApproved> underDoingrayadah([FromForm] ServicesApproveViewPageModel services)
        {

            TbSrRepService oTbSrRepService = ctx.TbSrRepServices.Where(a=> a.Id == services.SrRepId).FirstOrDefault();
            return ctx.TbServicesApproveds.Where(a => a.ServiceSyntax != "Finished").Include(a => a.Service).Include(a => a.TbServiceApprovedMilstones).ToList().Where(a => a.SrApprovedDescription == oTbSrRepService.ServiceId.ToString());
        }

        // PUT api/<ServicesApprovedApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesApprovedApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
