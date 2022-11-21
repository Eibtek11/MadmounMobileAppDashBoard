using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesOfferApiController : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        ServicesOfferService servicesOfferService;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesOfferApiController(UserManager<ApplicationUser> usermanager, ServicesOfferService ServicesOfferService,ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            servicesOfferService = ServicesOfferService;
            Usermanager = usermanager;
        }
        // GET: api/<ServicesOfferApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServicesOfferApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServicesRequired> Get(string id)
        {
            return ctx.TbServicesRequireds.Include(a => a.Service).Include(a=> a.TbServicesOfferss).ToList().Where(a => a.SrReqId == id);
        }

        // POST api/<ServicesOfferApiController>
        [HttpPost("offerService")]
        public IActionResult Post([FromForm] ServicesOfferViewPageModel services)
        {
            TbServicesOffers oTbServicesOffers = new TbServicesOffers();
            oTbServicesOffers.OfferSyntax = services.OfferSyntax;
            oTbServicesOffers.ServiceOfferCost = services.ServiceOfferCost;
            oTbServicesOffers.ServiceOfferDuration = services.ServiceOfferDuration;
            oTbServicesOffers.ServicesRequiredId = services.ServicesRequiredId;
            oTbServicesOffers.SrOffId = services.SrOffId;
            oTbServicesOffers.SrRepId = services.SrRepId;
            oTbServicesOffers.SrReqId = services.SrReqId;
            oTbServicesOffers.ServiceId = services.ServiceId;
            oTbServicesOffers.CreatedBy =ctx.TbServices.Where(a=> a.ServiceId == services.ServiceId).FirstOrDefault().ServiceName;
            oTbServicesOffers.UpdatedBy = ctx.TbServices.Where(a => a.ServiceId == services.ServiceId).FirstOrDefault().CreatedBy;
            oTbServicesOffers.Notes = "بانتظار الرد";
            var result = servicesOfferService.Add(oTbServicesOffers);

            if (!result)
            {
                return Unauthorized();

            }
            return Ok(result);
        }





        // PUT api/<ServicesOfferApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesOfferApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
