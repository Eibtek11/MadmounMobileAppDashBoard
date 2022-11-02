using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesApprovedImageApiController : ControllerBase
    {
        ServiceApprovedImagesService serviceApprovedImagesService;
        ServiceApprovedMilstoneService serviceApprovedMilstoneService;
        ServicesOfferService servicesOfferService;
        ServicesRequiredService servicesRequiredService;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesApprovedImageApiController(ServiceApprovedImagesService ServiceApprovedImagesService,ServiceApprovedMilstoneService ServiceApprovedMilstoneService, ServicesOfferService ServicesOfferService, ServicesRequiredService ServicesRequiredService, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            servicesRequiredService = ServicesRequiredService;
            servicesOfferService = ServicesOfferService;
            serviceApprovedMilstoneService = ServiceApprovedMilstoneService;
            serviceApprovedImagesService = ServiceApprovedImagesService;
        }
        // GET: api/<ServicesApprovedImageApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServicesApprovedImageApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ServicesApprovedImageApiController>
        [HttpPost("imageApprove")]
        public IActionResult Post([FromForm] ServiceApprovedImagesViewPageModel services)
        {
            TbServiceApprovedImage oTbServiceApprovedImage = new TbServiceApprovedImage();

           
            oTbServiceApprovedImage.CreatedBy = services.CreatedBy;
            oTbServiceApprovedImage.ServiceApprovedId = services.ServiceApprovedId;


            var result = serviceApprovedImagesService.Add(oTbServiceApprovedImage , services.ImagePath);

            if (!result)
            {
                return Unauthorized();

            }
            return Ok(result);
        }

        // PUT api/<ServicesApprovedImageApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesApprovedImageApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
