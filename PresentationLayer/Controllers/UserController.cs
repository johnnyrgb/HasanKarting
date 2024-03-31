using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            return await Task.Run(() => _userService.GetUsers());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            return await Task.Run(() => _userService.GetUser(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post(UserDTO item)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            await Task.Run(() => _userService.CreateUser(new UserDTO()
            {
                Firstname = item.Firstname,
                Lastname = item.Lastname,
                Email = item.Email,
                Password = item.Password,
                Username = item.Username,
            }));
            return CreatedAtAction("Get", new { Id = item.Id }, item);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put(UserDTO item)
        {
            await Task.Run(() => _userService.UpdateUser(item));
            return CreatedAtAction("Get", new { Id = item.Id }, item);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await Task.Run(() => _userService.DeleteUser(id));
        }
    }
}
