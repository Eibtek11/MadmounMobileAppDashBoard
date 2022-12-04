using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesRequiredApiController : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesRequiredApiController(UserManager<ApplicationUser> usermanager, ServicesRequiredService ServicesRequiredService,ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            Usermanager = usermanager;
        }
        // GET: api/<ServicesRequiredApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServicesRequiredApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbServicesRequired> Get(string id)
        {
            List<TbSrRepService> lstSrRepServices = ctx.TbSrRepServices.Where(a => a.Id == id).ToList();
            List<TbServicesRequired> lstServicesRequired = ctx.TbServicesRequireds.ToList();
            List<TbServicesRequired> lstServicesRequiredFinal = new List<TbServicesRequired>();
            foreach (var i in lstSrRepServices)
            {
               foreach(var ii in lstServicesRequired.Where(a=> a.ApprovalStatus != "Approved"))
                {
                    if(i.ServiceId == ii.ServiceId)
                    {
                        lstServicesRequiredFinal.Add(ii);
                    }
                }
            }
            return lstServicesRequiredFinal;
        }

        // POST api/<ServicesRequiredApiController>
        [HttpPost("SendService")]
        public async Task<IActionResult> PostAsync([FromForm] ServicesRequiredViewPageModel services)
        {
            var user = await Usermanager.FindByIdAsync(services.SrReqId);

            TbServicesRequired oTbServicesRequired = new TbServicesRequired();
            if(user.ServiceId!=null)
            {
                oTbServicesRequired.RyadahOrNot = user.ServiceId.ToString();
            }
            oTbServicesRequired.ServiceSyntax = services.ServiceSyntax;
           
            oTbServicesRequired.SrReqId = services.SrReqId;
            oTbServicesRequired.ServiceId = services.ServiceId;
            oTbServicesRequired.CreatedBy = services.CreatedBy;
            oTbServicesRequired.CreatedDate = DateTime.Now;
            oTbServicesRequired.UpdatedBy = Usermanager.Users.Where(a=> a.Id == oTbServicesRequired.SrReqId).FirstOrDefault().ServiceCategoryName;
            oTbServicesRequired.Notes = services.Notes;
            oTbServicesRequired.SrReqName = Usermanager.Users.Where(a => a.Id == oTbServicesRequired.SrReqId).FirstOrDefault().Email;
            oTbServicesRequired.ServiceName = ctx.TbServices.Where(a => a.ServiceId == services.ServiceId).FirstOrDefault().ServiceName;
            oTbServicesRequired.ServiceImage = ctx.TbServices.Where(a => a.ServiceId == services.ServiceId).FirstOrDefault().CreatedBy;
            var result = servicesRequiredService.Add(oTbServicesRequired);

            if (!result)
            {
                return Unauthorized();

            }
            return Ok(result);
        }


        [HttpPost("SendServiceBySrRep")]
        public IActionResult SendServiceBySrRep([FromForm] ServicesRequiredBySrRepViewPageModel services)
        {
            TbServicesRequired oTbServicesRequired = ctx.TbServicesRequireds.Where(a => a.ServicesRequiredId == services.ServicesRequiredId).FirstOrDefault();
            oTbServicesRequired.SrRepId = services.SrRepId;

           

            var result = servicesRequiredService.Edit(oTbServicesRequired);

            if (!result)
            {
                return Unauthorized();

            }
            return Ok(result);
        }
        [HttpPost("SendServiceBySrRepLast")]
        public IActionResult SendServiceBySrRepLast([FromForm] ServicesRequiredBySrRepViewPageModelLast services)
        {
            TbServicesRequired oTbServicesRequired = ctx.TbServicesRequireds.Where(a => a.ServicesRequiredId == services.ServicesRequiredId).FirstOrDefault();
            oTbServicesRequired.SrRequiredDescription = services.SrRequiredDescription;
            oTbServicesRequired.SrRepId = services.SrRepId;
            oTbServicesRequired.SrReqName = Usermanager.Users.Where(a=> a.Id == oTbServicesRequired.SrReqId).FirstOrDefault().Email;


            var result = servicesRequiredService.Edit(oTbServicesRequired);

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
