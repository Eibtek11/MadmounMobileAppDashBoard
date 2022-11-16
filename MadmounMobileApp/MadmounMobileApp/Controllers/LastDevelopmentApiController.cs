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
    public class LastDevelopmentApiController : ControllerBase
    {
        LastDevelopmentService lastDevelopmentService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public LastDevelopmentApiController(LastDevelopmentService LastDevelopmentService,AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            lastDevelopmentService = LastDevelopmentService;
        }
        // GET: api/<LastDevelopmentApiController>
        [HttpGet]
        public IEnumerable<TbLastDevelopments> Get()
        {
            HomePageModel model = new HomePageModel();
            model.LstLastDevelopments = lastDevelopmentService.getAll();
            return model.LstLastDevelopments;
        }

        // GET api/<LastDevelopmentApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LastDevelopmentApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LastDevelopmentApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LastDevelopmentApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
