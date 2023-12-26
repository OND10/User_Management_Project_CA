using Microsoft.AspNetCore.Mvc;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userservice;

        public UserController(IUserService userservice)
        {        
            _userservice = userservice;
        }

      

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserResponseDTO>> Get()
        {
            var result = await _userservice.GetAllAsync();

            return result.Data;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<bool> Post(UserRequestDTO model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    var addres = await _userservice.CreateAsync(model);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
