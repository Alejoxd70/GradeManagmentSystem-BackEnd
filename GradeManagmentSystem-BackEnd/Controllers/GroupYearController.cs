using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> CreateGroupYear([FromForm] GroupYear groupYear)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _groupYearService.CreateGroupYearAsync(groupYear);
            return CreatedAtAction(nameof(GetGroupYearById), new { id = groupYear.Id }, groupYear);
        }


        // Update a GroupYear
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateGroupYear(int id, [FromForm] GroupYear groupYear)
        {
            if (id != groupYear.Id) return BadRequest();

            var existingGroupYear = await _groupYearService.GetGroupYearByIdAsync(id);
            if (existingGroupYear == null) return NotFound();

            await _groupYearService.UpdateGroupYearAsync(groupYear);
            return NoContent();
        }

        // Delete a GroupYear
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteGroupYear(int id)
        {
            var groupyear = await _groupYearService.GetGroupYearByIdAsync(id);
            if (groupyear == null) return NotFound();

            await _groupYearService.SoftDeleteGroupYearAsync(id);
            return NoContent();
        }
    }
}
