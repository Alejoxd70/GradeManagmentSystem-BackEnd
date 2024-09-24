using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeManagmentSystem_BackEnd.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypesController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }


        // Get all userTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserType>>> GetAllUserTypes()
        {
            var userTypes = await _userTypeService.GetAllUserTypesAsync();
            return Ok(userTypes);
        }


        // Get userType by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserType>> GetUserTypeById(int id)
        {
            var userType = await _userTypeService.GetUserTypeByIdAsync(id);
            if (userType == null) return NotFound();

            return Ok(userType);
        }



        // Create a UserType
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUserType([FromForm] UserType userType)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _userTypeService.CreateUserTypeAsync(userType);
            return CreatedAtAction(nameof(GetUserTypeById), new { id = userType.Id }, userType);
        }


        // Update a UserType
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateUserType(int id, [FromForm] UserType userType)
        {
            if (id != userType.Id) return BadRequest();

            var existingUserType = await _userTypeService.GetUserTypeByIdAsync(id);
            if (existingUserType == null) return NotFound();

            await _userTypeService.UpdateUserTypeAsync(userType);
            return NoContent();
        }

        // Delete a userType
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteUserType(int id)
        {
            var userType = await _userTypeService.GetUserTypeByIdAsync(id);
            if (userType == null) return NotFound();

            await _userTypeService.SoftDeleteUserTypeAsync(id);
            return NoContent();
        }

    }
}
