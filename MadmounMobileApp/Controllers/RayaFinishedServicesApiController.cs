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
    public class RayaFinishedServicesApiController : ControllerBase
    {
        ServicesApprovedService serviceApprovedService;
        UserManager<ApplicationUser> Usermanager;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public RayaFinishedServicesApiController(ServicesApprovedService ServiceApprovedService, UserManager<ApplicationUser> usermanager, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            Usermanager = usermanager;
            serviceApprovedService = ServiceApprovedService;
        }
        // GET: api/<RayaFinishedServicesApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RayaFinishedServicesApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServicesApproved> Get(string id)
        {

            TbSrRepService oTbSrRepService = ctx.TbSrRepServices.Where(a => a.Id == id).FirstOrDefault();
            return ctx.TbServicesApproveds.Include(a => a.Service).Include(a => a.City).ToList().Where(a => a.SrApprovedDescription == oTbSrRepService.ServiceId.ToString()).Where(a => a.ServiceSyntax == "Finished");
        }

        // POST api/<RayaFinishedServicesApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RayaFinishedServicesApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RayaFinishedServicesApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
