using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Cors;
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
    public class ServicesApiController : ControllerBase
    {
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ServicesApiController(AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
        }
        // GET: api/<ServicesApiController>
        [HttpGet]
        public IEnumerable<TbService> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstServices = serviceService.getAll().Where(a=> a.ServiceCategoryId != Guid.Parse("371b893c-3f5a-4335-a2c0-b9aa197d35ae"));
            return model.lstServices;
        }

        // GET api/<ServicesApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbService> Get(Guid id)
        {
            HomePageModel model = new HomePageModel();

            model.lstServices = serviceService.getAll().Where(a => a.ServiceCategoryId == id).ToList();
            return model.lstServices;
        }

        // POST api/<ServicesApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServicesApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
