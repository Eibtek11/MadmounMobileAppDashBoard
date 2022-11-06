using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesApprovedApiController : ControllerBase
    {
        ServicesApprovedService servicesApprovedService;
        ServicesOfferService servicesOfferService;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesApprovedApiController(ServicesApprovedService ServicesApprovedService,ServicesOfferService ServicesOfferService, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            servicesOfferService = ServicesOfferService;
            servicesApprovedService = ServicesApprovedService;
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
            return ctx.TbServicesApproveds.Where(a => a.SrRepId == id).ToList();
        }

        // POST api/<ServicesApprovedApiController>
        [HttpPost("approveService")]
        public IActionResult Post([FromForm] ServicesApproveViewPageModel services)
        {
            TbServicesApproved oTbServicesApproved = new TbServicesApproved();
            oTbServicesApproved.SrRepId = services.SrRepId;
            oTbServicesApproved.SrReqId = services.SrReqId;
            oTbServicesApproved.SrOffId = services.SrOffId;
            oTbServicesApproved.CreatedBy = services.CreatedBy;
            oTbServicesApproved.Notes = services.Notes;
            oTbServicesApproved.ServiceId = services.ServiceId;
            oTbServicesApproved.CityId = services.CityId;
            oTbServicesApproved.AreaId = services.AreaId;

            var result = servicesApprovedService.Add(oTbServicesApproved);

            if (!result)
            {
                return Unauthorized();

            }
            return Ok(result);
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
