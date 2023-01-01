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
    public class ServiceRequiredApiGetApproved : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServiceRequiredApiGetApproved(UserManager<ApplicationUser> usermanager, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            Usermanager = usermanager;
        }
        // GET: api/<ServiceRequiredApiGetApproved>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServiceRequiredApiGetApproved>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServicesRequired> Get(string id)
        {
            List<TbSrRepService> lstSrRepServices = ctx.TbSrRepServices.Where(a => a.Id == id).ToList();
            List<TbServicesRequired> lstServicesRequired = ctx.TbServicesRequireds.Where(a => a.Status == "Approved").ToList();
            List<TbServicesRequired> lstServicesRequiredFinal = new List<TbServicesRequired>();
            foreach (var i in lstSrRepServices)
            {
                foreach (var ii in lstServicesRequired.Where(a => a.ApprovalStatus != "Approved"))
                {
                    if (i.ServiceId == ii.ServiceId)
                    {
                        lstServicesRequiredFinal.Add(ii);
                    }
                }
            }
            return lstServicesRequiredFinal;
        }

        // POST api/<ServiceRequiredApiGetApproved>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServiceRequiredApiGetApproved>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiceRequiredApiGetApproved>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
