using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesOfferApiController : ControllerBase
    {
        ServicesOfferService servicesOfferService;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesOfferApiController(ServicesOfferService ServicesOfferService,ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            servicesOfferService = ServicesOfferService;
        }
        // GET: api/<ServicesOfferApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServicesOfferApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
