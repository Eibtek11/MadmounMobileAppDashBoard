using BL;
using Domains;
using MadmounMobileApp.Models;
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
    public class AdviceApiController : ControllerBase
    {
        AdviceService adviceService;
        AdvertismentService advertismentService;
        ServiceCategoryService srviceCategoryService;
        ServiceService serviceService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public AdviceApiController(AdviceService AdviceService ,AdvertismentService AdvertismentService, ServiceCategoryService SrviceCategoryService, ServiceService ServiceService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
           
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            serviceService = ServiceService;
            srviceCategoryService = SrviceCategoryService;
            advertismentService = AdvertismentService;
            adviceService = AdviceService;
    }
        // GET: api/<AdviceApiController>
        [HttpGet]
        public IEnumerable<TbAdvices> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstAdvices = adviceService.getAll();
            return model.lstAdvices;
        }

        // GET api/<AdviceApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdviceApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdviceApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdviceApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
