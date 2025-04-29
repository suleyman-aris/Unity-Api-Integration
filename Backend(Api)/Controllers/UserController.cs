using Microsoft.AspNetCore.Mvc;
using Login.Business;

namespace Login.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] string name)
        {
            var user = await _service.CreateUserAsync(name);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] string name)
        {
            var updatedUser = await _service.UpdateUserAsync(id, name);
            if (updatedUser == null) return NotFound();
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _service.DeleteUserAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
