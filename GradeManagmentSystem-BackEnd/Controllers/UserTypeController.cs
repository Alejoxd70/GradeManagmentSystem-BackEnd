using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GradeManagmentSystem_BackEnd.Services.ISubjectTeacherService;

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
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateUserType(string name)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _userTypeService.CreateUserTypeAsync(name);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }


            return StatusCode(StatusCodes.Status201Created, "UserType created successfully.");

        }


        // Update a UserType
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult> UpdateUserType(int id, string name)
        {

            var existingUserType = await _userTypeService.GetUserTypeByIdAsync(id);
            if (existingUserType == null) return NotFound();

           
            try
            {
                await _userTypeService.UpdateUserTypeAsync(id, name);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // Delete a userType
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult> SoftDeleteUserType(int id)
        {
            var userType = await _userTypeService.GetUserTypeByIdAsync(id);
            if (userType == null) return NotFound();

            try
            {
                await _userTypeService.SoftDeleteUserTypeAsync(id);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);
            }
        }

    }
}
