using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeManagmentSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionUserTypesController : ControllerBase
    {
        private readonly IPermissionUserTypeService _permissionUserTypeService;

        public PermissionUserTypesController(IPermissionUserTypeService permissionUserTypeService)
        {
            _permissionUserTypeService = permissionUserTypeService;
        }


        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PermissionUserType>>> GetAllPermissionUserTypes()
        {
            var permissionUserTypes = await _permissionUserTypeService.GetAllPermissionUserTypesAsync();
            return Ok(permissionUserTypes);
        }


       
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermissionUserType>> GetPermissionUserTypesById(int id)
        {
            var permissionUserType = await _permissionUserTypeService.GetPermissionUserTypeByIdAsync(id);
            if (permissionUserType == null) return NotFound();

            return Ok(permissionUserType);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePermissionUserType( int userTypeId, int permissionId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _permissionUserTypeService.CreatePermissionUserTypeAsync(userTypeId, permissionId);

            return StatusCode(StatusCodes.Status201Created, "Permission UserType created successfully.");

        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdatePermissionUserType(int id,  int userTypeId, int permissionId)
        {

            var existingPermissionUserType = await _permissionUserTypeService.GetPermissionUserTypeByIdAsync(id);
            if (existingPermissionUserType == null) return NotFound();

            try
            {
                await _permissionUserTypeService.UpdatePermissionUserTypeAsync(id, userTypeId, permissionId);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                throw;
            }
        }

    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeletePermissionUserType(int id)
        {
            var permissionUserType = await _permissionUserTypeService.GetPermissionUserTypeByIdAsync(id);
            if (permissionUserType == null) return NotFound();


            try
            {
                await _permissionUserTypeService.SoftDeletePermissionUserTypeAsync(id);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}