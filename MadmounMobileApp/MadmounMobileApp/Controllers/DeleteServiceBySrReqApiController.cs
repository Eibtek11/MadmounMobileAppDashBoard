using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteServiceBySrReqApiController : ControllerBase
    {
        ServicesOfferService servicesOfferService;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public DeleteServiceBySrReqApiController(ServicesOfferService ServicesOfferService, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            servicesOfferService = ServicesOfferService;
        }
        // GET: api/<DeleteServiceBySrReqApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DeleteServiceBySrReqApiController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            TbServicesApproved oTbServicesApproved = ctx.TbServicesApproveds.Where(a => a.CreatedBy == id).FirstOrDefault();
            if (oTbServicesApproved != null)
            {
                return "The Service already has millestones we can not delete";
            }
            else
            {
                TbServicesRequired oTbServicesRequireds = ctx.TbServicesRequireds.Where(a => a.ServicesRequiredId == Guid.Parse(id)).FirstOrDefault();
                bool result = servicesRequiredService.Delete(oTbServicesRequireds);
                if (result)
                {
                    return "The Service Is Delted";
                }
                else
                {
                    return "No Service Is Delted";
                }

            }

        }

        // POST api/<DeleteServiceBySrReqApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DeleteServiceBySrReqApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeleteServiceBySrReqApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
