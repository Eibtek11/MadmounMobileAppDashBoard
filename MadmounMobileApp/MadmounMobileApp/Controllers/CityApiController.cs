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
    public class CityApiController : ControllerBase
    {
        CityService cityService;
        MadmounDbContext ctx;
        public CityApiController(CityService Cityservice, MadmounDbContext context)
        {
            cityService = Cityservice;
            ctx = context;

        }
        // GET: api/<CityApiController>
        [HttpGet]
        public IEnumerable<TbCity> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstCities = cityService.getAll();
            return model.lstCities;
        }

        // GET api/<CityApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CityApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CityApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CityApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
