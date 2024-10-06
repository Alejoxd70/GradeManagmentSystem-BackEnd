using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace GradeManagmentSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupYearController : ControllerBase
    {
        private readonly IGroupYearService _groupYearService;

        public GroupYearController(IGroupYearService groupYearService)
        {
            _groupYearService = groupYearService;
        }

        // Get all GroupYear
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GroupYear>>> GroupYears()
        {
            var groupyeaars = await _groupYearService.GetAllGroupYearsAsync();
            return Ok(groupyeaars);
        }


        // Get GroupYear by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GroupYear>> GetGroupYearById(int id)
        {
            var groupyear = await _groupYearService.GetGroupYearByIdAsync(id);
            if (groupyear == null) return NotFound();

            return Ok(groupyear);
        }



        // Create a GroupYear
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateGroupYear(string year, int studentId, int groupId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _groupYearService.CreateGroupYearAsync(year, studentId, groupId);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }

            return StatusCode(StatusCodes.Status201Created, "GroupYear successfully created");
        }


        // Update a GroupYear
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult> UpdateGroupYear(int id, string year, int studentId, int groupId)
        {

            var existingGroupYear = await _groupYearService.GetGroupYearByIdAsync(id);
            if (existingGroupYear == null) return NotFound();

            try
            {
                await _groupYearService.UpdateGroupYearAsync(id, year, studentId, groupId);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // Delete a GroupYear
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult> SoftDeleteGroupYear(int id)
        {
            var groupyear = await _groupYearService.GetGroupYearByIdAsync(id);
            if (groupyear == null) return NotFound();

            try
            {
                await _groupYearService.SoftDeleteGroupYearAsync(id);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);
            }
        }
    }
}
