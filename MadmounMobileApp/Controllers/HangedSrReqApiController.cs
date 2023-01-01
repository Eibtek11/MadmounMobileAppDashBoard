using BL;
using Domains;
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
    public class HangedSrReqApiController : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public HangedSrReqApiController(UserManager<ApplicationUser> usermanager, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            Usermanager = usermanager;
        }
        // GET: api/<HangedSrReqApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HangedSrReqApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServicesRequired> Get(string id)
        {


            return ctx.TbServicesRequireds.Include(a => a.Service).ToList().Where(a => a.SrReqId == id).Where(a=> a.SrRequiredDescription == null || a.SrRequiredDescription == string.Empty);
        }

        // POST api/<HangedSrReqApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HangedSrReqApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HangedSrReqApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
