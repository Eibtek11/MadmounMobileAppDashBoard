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
    public class OffServicesRequiredApiController : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public OffServicesRequiredApiController(UserManager<ApplicationUser> usermanager, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            Usermanager = usermanager;
        }
        // GET: api/<OffServicesRequiredApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OffServicesRequiredApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServicesRequired> Get(string id)
        {
            List<TbSrOffService> lstSrOffServices = ctx.TbSrOffServices.Where(a => a.Id == id).ToList();
            List<TbServicesRequired> lstServicesRequired = ctx.TbServicesRequireds.Where(a => a.SrRequiredDescription != null).ToList();
            List<TbServicesRequired> lstServicesRequiredFinal = new List<TbServicesRequired>();
            List<TbServicesRequired> lstServicesRequiredFinal2 = new List<TbServicesRequired>();
            foreach (var i in lstSrOffServices)
            {
                foreach (var ii in lstServicesRequired.Where(a => a.ApprovalStatus != "Approved"))
                {
                    if (i.ServiceId == ii.ServiceId)
                    {
                        lstServicesRequiredFinal.Add(ii);
                    }
                }
            }
            foreach(var i in lstServicesRequiredFinal)
            {
                lstServicesRequiredFinal2.Add(i);
            }
           
            foreach (var i in ctx.TbServicesOfferss.ToList())
            {
                foreach(var e in lstServicesRequiredFinal)
                {
                    if(e.ServicesRequiredId == i.ServicesRequiredId && i.SrOffId == id)
                    {
                        lstServicesRequiredFinal2.Remove(e);
                    }
                }
            }
            
            return lstServicesRequiredFinal2;
        }

        // POST api/<OffServicesRequiredApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OffServicesRequiredApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OffServicesRequiredApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
