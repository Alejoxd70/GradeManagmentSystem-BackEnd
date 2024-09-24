using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradeManagmentSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }


        // Get all grades
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Grade>>> GetAllGrades()
        {
            var grades = await _gradeService.GetAllGradesAsync();
            return Ok(grades);
        }


        // Get grade by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Grade>> GetGradeById(int id)
        {
            var grade = await _gradeService.GetGradeByIdAsync(id);
            if (grade == null) return NotFound();

            return Ok(grade);
        }



        // Create a grade
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateGrade([FromForm] Grade grade)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _gradeService.CreateGradeAsync(grade);
            return CreatedAtAction(nameof(GetGradeById), new { id = grade.Id }, grade);
        }


        // Update a grade
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateGrade(int id, [FromForm] Grade grade)
        {
            if (id != grade.Id) return BadRequest();

            var existingGrade = await _gradeService.GetGradeByIdAsync(id);
            if (existingGrade == null) return NotFound();

            await _gradeService.UpdateGradeAsync(grade);
            return NoContent();
        }

        // Delete a grade
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteGrade(int id)
        {
            var grade = await _gradeService.GetGradeByIdAsync(id);
            if (grade == null) return NotFound();

            await _gradeService.SoftDeleteGradeAsync(id);
            return NoContent();
        }

    }
}
