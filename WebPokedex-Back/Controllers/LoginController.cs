using Microsoft.AspNetCore.Mvc;
using WebPokedex.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebPokedex.Controllers // to add oher controllers, just add a new class and change the name of the controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _LoginServices;
        public LoginController(ILoginServices LoginServices) 
        {
            _LoginServices = LoginServices;
        }   


        // GET: api/LoginController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _LoginServices.GetAllAsync();
            return Ok(data);
        }

        // GET api/LoginController/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/LoginController
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/LoginController/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/LoginController/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
