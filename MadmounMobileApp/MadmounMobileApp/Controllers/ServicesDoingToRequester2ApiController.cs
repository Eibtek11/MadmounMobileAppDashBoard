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
    public class ServicesDoingToRequester2ApiController : ControllerBase
    {
        ServicesApprovedService serviceApprovedService;
        UserManager<ApplicationUser> Usermanager;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesDoingToRequester2ApiController(ServicesApprovedService ServiceApprovedService, UserManager<ApplicationUser> usermanager, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            Usermanager = usermanager;
            serviceApprovedService = ServiceApprovedService;
        }
        // GET: api/<ServicesDoingToRequester2ApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServicesDoingToRequester2ApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServicesApproved> Get(string id)
        {
            List<TbServicesApproved> lstServicesApproved = ctx.TbServicesApproveds.Where(a => a.SrReqId == id).ToList();
            List<TbServiceApprovedMilstone> lstServiceApprovedMilstone = ctx.TbServiceApprovedMilstones.ToList();
            List<TbServicesApproved> lstServicesApprovedFinal = new List<TbServicesApproved>();
            foreach (var item in lstServicesApproved)
            {
                foreach (var element in lstServiceApprovedMilstone)
                {
                    if (item.ServiceApprovedId == element.ServiceApprovedId)
                    {
                        lstServicesApprovedFinal.Add(item);

                    }
                }

            }

            var resultset = lstServicesApprovedFinal
           .GroupBy(ddda => ddda.ServiceApprovedId)
           .ToList();
            List<TbServicesApproved> lstServicesApprovedFinal2 = new List<TbServicesApproved>();
            foreach (var i in resultset)
            {
                foreach (var item in lstServicesApproved)
                {
                    if (item.ServiceApprovedId == i.Key)
                    {
                        lstServicesApprovedFinal2.Add(item);
                    }

                }


            }


            return lstServicesApprovedFinal2;
            //return ctx.TbServicesApproveds.Include(a => a.TbServiceApprovedMilstones).ToList().Where(a => a.SrReqId == id);
        }

        // POST api/<ServicesDoingToRequester2ApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServicesDoingToRequester2ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesDoingToRequester2ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
