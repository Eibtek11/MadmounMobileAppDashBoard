using BL;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMillestoneApiController : ControllerBase
    {
        ServicesApprovedService serviceApprovedService;
        UserManager<ApplicationUser> Usermanager;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ProjectMillestoneApiController(ServicesApprovedService ServiceApprovedService, UserManager<ApplicationUser> usermanager, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            Usermanager = usermanager;
            serviceApprovedService = ServiceApprovedService;
        }
        // GET: api/<ProjectMillestoneApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProjectMillestoneApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServiceApprovedMilstone> Get(string id)
        {

            return ctx.TbServiceApprovedMilstones.Where(a => a.ServiceApprovedId == Guid.Parse(id)).ToList();
        }

        // POST api/<ProjectMillestoneApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProjectMillestoneApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProjectMillestoneApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
