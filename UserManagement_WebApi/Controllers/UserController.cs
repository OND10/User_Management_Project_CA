using Microsoft.AspNetCore.Mvc;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services;
using UserManagement_Application.Utly;
using UserManagement_Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement_WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IUserRepository _userRepository;
        private IUserService @object;

        public UserController(IUserService service,IUserRepository userRepository)
        {
            _service = service;
            _userRepository = userRepository;
        }

        public UserController(IUserService @object)
        {
            this.@object = @object;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserResponseDTO>> Get()
        {
            var list=await _service.GetAllAsync();
            return list.Data;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<bool> Post([FromBody] UserRequestDTO model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    var addres = await _service.CreateAsync(model);
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
        public async Task<bool> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var delete = await _service.GetByIdAsync(id);
                    _ = await _service.DeleteAsync(delete.Data);
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(id));
            }

        }
    }
}
