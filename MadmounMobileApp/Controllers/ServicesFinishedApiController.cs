using BL;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesFinishedApiController : ControllerBase
    {
        ServicesFinishedService servicesFinished;
        ServicesApprovedService servicesApprovedService;
        ServicesOfferService servicesOfferService;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesFinishedApiController(ServicesFinishedService ServicesFinished, ServicesApprovedService ServicesApprovedService, ServicesOfferService ServicesOfferService, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            servicesOfferService = ServicesOfferService;
            servicesApprovedService = ServicesApprovedService;
            servicesFinished = ServicesFinished;
        }
        // GET: api/<ServicesFinishedApiController>
        [HttpGet]
        public IEnumerable<TbServicesFinished> Get(string id)
        {
            return ctx.TbServicesFinisheds.Where(a => a.SrRepId == id).ToList();
        }

        // GET api/<ServicesFinishedApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ServicesFinishedApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServicesFinishedApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesFinishedApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
