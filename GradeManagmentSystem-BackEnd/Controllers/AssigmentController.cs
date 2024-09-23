using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeManagmentSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssigmentsController : ControllerBase
    {
        private readonly IAssigmentService _assigmentService;

        public AssigmentsController(IAssigmentService assigmentService)
        {
            _assigmentService = assigmentService;
        }


        // Get all Assigments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Assigment>>> GetAllAssigments()
        {
            var assigments = await _assigmentService.GetAllAssigmentsAsync();
            return Ok(assigments);
        }


        // Get Asigment by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Assigment>> GetAssigmentById(int id)
        {
            var assigment = await _assigmentService.GetAssigmentByIdAsync(id);
            if (assigment == null) return NotFound();

            return Ok(assigment);
        }



        // Create a Assigment
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAssigment([FromBody] Assigment assigment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _assigmentService.CreateAssigmentAsync(assigment);
            return CreatedAtAction(nameof(GetAssigmentById), new { id = assigment.Id }, assigment);
        }


        // Update a Assigment
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateAssigment(int id, [FromBody] Assigment assigment)
        {
            if (id != assigment.Id) return BadRequest();

            var existingAssigment = await _assigmentService.GetAssigmentByIdAsync(id);
            if (existingAssigment == null) return NotFound();

            await _assigmentService.UpdateAssigmentAsync(assigment);
            return NoContent();
        }

        // Delete a Assigment
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteAssigment(int id)
        {
            var assigment = await _assigmentService.GetAssigmentByIdAsync(id);
            if (assigment == null) return NotFound();

            await _assigmentService.SoftDeleteAssigmentAsync(id);
            return NoContent();
        }
    }
}
