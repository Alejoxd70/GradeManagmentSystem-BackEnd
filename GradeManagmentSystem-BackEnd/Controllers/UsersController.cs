using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using static GradeManagmentSystem_BackEnd.Services.ISubjectTeacherService;

namespace GradeManagmentSystem_BackEnd.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // Get all users
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }


        // Get user by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }



        // Create a User
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateUser(string name, string lastName, string email, string password, string identification, int userTypeId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _userService.CreateUserAsync(name, lastName, email, password, identification, userTypeId);
            } catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }


            return StatusCode(StatusCodes.Status201Created, "User created successfully.");

        }

        // Validate a user Login
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> ValidateUser(string email, string password)
        {
            if(email == null || password == null) return BadRequest(ModelState);

            // Validate the user
            try
            {
                var isValid = await _userService.ValidateUserAsync(email, password);
                if (isValid)
                {
                    // Handle successful login  
                    return Ok(new { Message = "Login successful" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }

            // Handle failed login
            return Unauthorized(new { Message = "Invalid Password" });
        }


        // Update a User
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult> UpdateUser(int id, string name, string lastName, string email, string password, string identification, int userTypeId)
        {

            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null) return NotFound();

            try
            {
                await _userService.UpdateUserAsync(id, name, lastName, email, password, identification, userTypeId);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // Delete a user
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();


            try
            {
                await _userService.SoftDeleteUserAsync(id);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);
            }
        }

    }
}
