using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesApprovedMillestoneApiController : ControllerBase
    {
        ServiceApprovedMilstoneService serviceApprovedMilstoneService;
        ServicesOfferService servicesOfferService;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesApprovedMillestoneApiController(ServiceApprovedMilstoneService ServiceApprovedMilstoneService,ServicesOfferService ServicesOfferService, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            servicesOfferService = ServicesOfferService;
            serviceApprovedMilstoneService = ServiceApprovedMilstoneService;
        }
        // GET: api/<ServicesApprovedMillestoneApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServicesApprovedMillestoneApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServiceApprovedMilstone> Get(Guid id)
        {
            return ctx.TbServiceApprovedMilstones.Where(a => a.ServiceApprovedId == id).ToList();
        }

        // POST api/<ServicesApprovedMillestoneApiController>
        [HttpPost("millestone")]
        public IActionResult Post([FromForm] ServiceApprovedMillestoneViewPageModel services)
        {
            TbServiceApprovedMilstone oTbServiceApprovedMilstone = new TbServiceApprovedMilstone();
            oTbServiceApprovedMilstone.ServiceApprovedMilstoneDesc = services.ServiceApprovedMilstoneDesc;
            oTbServiceApprovedMilstone.CreatedBy = services.CreatedBy;
            oTbServiceApprovedMilstone.UpdatedBy = services.UpdatedBy;
            oTbServiceApprovedMilstone.ServiceApprovedId = services.ServiceApprovedId;
           

            var result = serviceApprovedMilstoneService.Add(oTbServiceApprovedMilstone);

            if (!result)
            {
                return Unauthorized();

            }
            return Ok(result);
        }

        // PUT api/<ServicesApprovedMillestoneApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesApprovedMillestoneApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
