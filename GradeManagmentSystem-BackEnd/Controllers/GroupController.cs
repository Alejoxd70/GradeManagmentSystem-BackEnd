using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GradeManagmentSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }


        // Get all groups
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Group>>> GetAllGroups()
        {
            var groups = await _groupService.GetAllGroupsAsync();
            return Ok(groups);
        }


        // Get group by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Group>> GetGroupById(int id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            if (group == null) return NotFound();

            return Ok(group);
        }



        // Create a group
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateGroup(string name)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _groupService.CreateGroupAsync(name);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }

            return StatusCode(StatusCodes.Status201Created, "Group created succesfully");
        }


        // Update a group
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult> UpdateGroup(int id, string name)
        {

            var existingGroup = await _groupService.GetGroupByIdAsync(id);
            if (existingGroup == null) return NotFound();

            try
            {
                await _groupService.UpdateGroupAsync(id, name);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // Delete a group
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult> SoftDeleteGroup(int id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            if (group == null) return NotFound();

            try
            {
                await _groupService.SoftDeleteGroupAsync(id);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);
            }
        }

    }
}
