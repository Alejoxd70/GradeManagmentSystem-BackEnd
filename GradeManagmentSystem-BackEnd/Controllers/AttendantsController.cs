using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeManagmentSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendantsController : ControllerBase
    {
        private readonly IAttendantService _attendantService;

        public AttendantsController(IAttendantService attendantService)
        {
            _attendantService = attendantService;
        }


        // Get all attendants
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Attendant>>> GetAllAttendants()
        {
            var attendants = await _attendantService.GetAllAttendantsAsync();
            return Ok(attendants);
        }


        // Get attendant by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Attendant>> GetAttendantById(int id)
        {
            var attendant = await _attendantService.GetAttendantByIdAsync(id);
            if (attendant == null) return NotFound();

            return Ok(attendant);
        }



        // Create a Attendant
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAttendant([FromForm] Attendant attendant)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _attendantService.CreateAttendantAsync(attendant);
            return CreatedAtAction(nameof(GetAttendantById), new { id = attendant.Id }, attendant);
        }


        // Update a Attendant
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateAttendant(int id, [FromForm] Attendant attendant)
        {
            if (id != attendant.Id) return BadRequest();

            var existingAttendant = await _attendantService.GetAttendantByIdAsync(id);
            if (existingAttendant == null) return NotFound();

            await _attendantService.UpdateAttendantAsync(attendant);
            return NoContent();
        }

        // Delete a attendant
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteAttendant(int id)
        {
            var attendant = await _attendantService.GetAttendantByIdAsync(id);
            if (attendant == null) return NotFound();

            await _attendantService.SoftDeleteAttendantAsync(id);
            return NoContent();
        }
    }
}
