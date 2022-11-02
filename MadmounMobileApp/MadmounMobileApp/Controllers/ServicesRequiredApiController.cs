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
    public class ServicesRequiredApiController : ControllerBase
    {
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesRequiredApiController(ServicesRequiredService ServicesRequiredService,ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
        }
        // GET: api/<ServicesRequiredApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServicesRequiredApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ServicesRequiredApiController>
        [HttpPost("SendService")]
        public IActionResult Post([FromForm] ServicesRequiredViewPageModel services)
        {
            TbServicesRequired oTbServicesRequired = new TbServicesRequired();
            oTbServicesRequired.ServiceSyntax = services.ServiceSyntax;
            oTbServicesRequired.SrRepId = services.SrRepId;
            oTbServicesRequired.SrReqId = services.SrReqId;
            oTbServicesRequired.ServiceId = services.ServiceId;

            var result = servicesRequiredService.Add(oTbServicesRequired);

            if (!result)
            {
                return Unauthorized();

            }
            return Ok(result);
        }


        // PUT api/<ServicesRequiredApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesRequiredApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
