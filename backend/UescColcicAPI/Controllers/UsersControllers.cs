using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using UescColcicAPI.Services.BD;

namespace UescColcicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserCRUD _usersCRUD;

        public UsersController(IUserCRUD usersCRUD)
        {
            _usersCRUD = usersCRUD;
        }
        
        [HttpGet(Name = "GetUsers")]
        [Authorize]
        public IEnumerable<User> Get()
        {
            return _usersCRUD.ReadAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        [Authorize]
        public ActionResult<User> Get(int id)
        {
            try
            {
                var user = _usersCRUD.ReadById(id);
                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateUser")] // Método de Update
        [Authorize]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is null.");
            }

            _usersCRUD.Update(user);
            return Ok("User updated successfully.");
        }

        [HttpDelete(Name = "DeleteUser")] // Método de Delete
        [Authorize]
        public IActionResult Delete([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is null.");
            }

            _usersCRUD.Delete(user);
            return Ok("User deleted successfully.");
        }

        [HttpPost(Name = "CreateUser")] // Método de Create
        [Authorize]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is null.");
            }

            try
            {
                _usersCRUD.Create(user);
                return CreatedAtAction(nameof(Get), new { username = user.Username }, user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Tratamento para nome de usuário duplicado
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating user: {ex.Message}");
            }
        }
    }
}