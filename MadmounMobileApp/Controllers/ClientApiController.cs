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
    public class ClientApiController : ControllerBase
    {
        CleintService cleintService;
        CityService cityService;
        MadmounDbContext ctx;
        public ClientApiController(CleintService CleintService, CityService Cityservice, MadmounDbContext context)
        {
            cityService = Cityservice;
            ctx = context;
            cleintService = CleintService;

        }
        // GET: api/<ClientApiController>
        [HttpGet]
        public IEnumerable<TbClients> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstClients = cleintService.getAll();
            return model.lstClients;
        }

        // GET api/<ClientApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<TbClientImages> Get(Guid id)
        {
            return ctx.TbClientImages.Where(a => a.ClientId == id).ToList();
        }

        // POST api/<ClientApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
