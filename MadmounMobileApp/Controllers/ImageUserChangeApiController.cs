using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUserChangeApiController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public ImageUserChangeApiController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        // GET: api/<ImageUserChangeApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ImageUserChangeApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ImageUserChangeApiController>
        [HttpPost]
        public async Task<IActionResult> editImage([FromForm] EditUserViewModell editModel)
        {
            var result = await _accountRepository.EditUsersImage(editModel);

            if (result == null)
            {
                return Unauthorized();

            }
            return Ok(result);

        }

        // PUT api/<ImageUserChangeApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImageUserChangeApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
