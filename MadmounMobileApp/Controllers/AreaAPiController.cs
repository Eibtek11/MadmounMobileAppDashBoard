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
    public class AreaAPiController : ControllerBase
    {
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public AreaAPiController(CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
        }
        // GET: api/<AreaAPiController>
        [HttpGet]
        public IEnumerable<TbArea> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstAreas = areaService.getAll();
            return model.lstAreas;
        }

        // GET api/<AreaAPiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AreaAPiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AreaAPiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AreaAPiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
