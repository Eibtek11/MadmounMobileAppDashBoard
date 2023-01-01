using BL;
using Domains;
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
    public class SrOfferCountApiController : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        ServicesOfferService servicesOfferService;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public SrOfferCountApiController(UserManager<ApplicationUser> usermanager, ServicesOfferService ServicesOfferService, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            servicesOfferService = ServicesOfferService;
            Usermanager = usermanager;
        }
        // GET: api/<SrOfferCountApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SrOfferCountApiController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return ctx.TbServicesOfferss.Where(a => a.ServicesRequiredId == Guid.Parse(id)).Count().ToString();
        }

        // POST api/<SrOfferCountApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SrOfferCountApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SrOfferCountApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
