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
    public class ComplainsApiController : ControllerBase
    {
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        public ComplainsApiController(ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
        }
        // GET: api/<ComplainsApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ComplainsApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ComplainsApiController>
        [HttpPost("SendComplain")]
        public IActionResult Post([FromForm] SendComplainModel sendComplainModel)
        {
            TbComplain oTbComplain = new TbComplain();
            oTbComplain.ComplainId = sendComplainModel.ComplainId;
            oTbComplain.CreatedBy = sendComplainModel.CreatedBy;
            oTbComplain.CreatedDate = sendComplainModel.CreatedDate;
            oTbComplain.Id = sendComplainModel.Id;
            oTbComplain.Notes = sendComplainModel.Notes; 
            var result =  ComplainService.Add(oTbComplain);

            if (!result)
            {
                return Unauthorized();

            }
            return Ok(result);
        }

        // PUT api/<ComplainsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComplainsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
