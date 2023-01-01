using MadmounMobileApp.Dtos;
using MadmounMobileApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSApiController : ControllerBase
    {
        private readonly ISMSService _smsService;

        public SMSApiController(ISMSService smsService)
        {
            _smsService = smsService;
        }
        // GET: api/<SMSApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SMSApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SMSApiController>
        [HttpPost("send")]
        public IActionResult Send(SendSMSDto dto)
        {
            var result = _smsService.Send(dto.MobileNumber, dto.Body);

            if (!string.IsNullOrEmpty(result.ErrorMessage))
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }

        // PUT api/<SMSApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SMSApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
