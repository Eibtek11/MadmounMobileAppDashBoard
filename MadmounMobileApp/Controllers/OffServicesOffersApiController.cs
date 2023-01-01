using BL;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffServicesOffersApiController : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public OffServicesOffersApiController(UserManager<ApplicationUser> usermanager, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            Usermanager = usermanager;
        }
        // GET: api/<OffServicesOffersApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OffServicesOffersApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServicesOffers> Get(string id)
        {
           
            return ctx.TbServicesOfferss.Where(a=> a.SrOffId == id).ToList();
        }

        // POST api/<OffServicesOffersApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OffServicesOffersApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OffServicesOffersApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
