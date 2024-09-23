using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GradeManagmentSystem_BackEnd.Services.ISubjectTeacherService;
namespace GradeManagmentSystem_BackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubjectTeachersController : ControllerBase
    {
        private readonly ISubjectTeacherService _subjectTeacherService;

        public SubjectTeachersController(ISubjectTeacherService subjectTeacherService)
        {
            _subjectTeacherService = subjectTeacherService;
        }

        // Get all SubjectTeacher
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SubjectTeacher>>> GetAllSubjectTeachers()
        {
            var subjectTeachers = await _subjectTeacherService.GetAllSubjectTeachersAsync();
            return Ok(subjectTeachers);
        }


        // Get SubjectTeacher by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubjectTeacher>> GetSubjectTeacherById(int id)
        {
            var subjectTeacher = await _subjectTeacherService.GetSubjectTeacherByIdAsync(id);
            if (subjectTeacher == null) return NotFound();

            return Ok(subjectTeacher);
        }



        // Create a SubjectTeacher
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateSubjectTeacher([FromBody] SubjectTeacher subjectTeacher)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _subjectTeacherService.CreateeSubjectTeacherAsync(subjectTeacher);
            return CreatedAtAction(nameof(GetSubjectTeacherById), new { id =subjectTeacher.Id }, subjectTeacher);
        }


        // Update a SubjectTeacher
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateSubjectTeacher(int id, [FromBody] SubjectTeacher subjectTeacher)
        {
            if (id != subjectTeacher.Id) return BadRequest();

            var existingSubjectTeacher = await _subjectTeacherService.GetSubjectTeacherByIdAsync(id);
            if (existingSubjectTeacher == null) return NotFound();

            await _subjectTeacherService.UpdateSubjectTeacherAsync(subjectTeacher);
            return NoContent();
        }

        // Delete a SubjectTeacher
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteSubjectTeacher(int id)
        {
            var subjectTeacher = await _subjectTeacherService.GetSubjectTeacherByIdAsync(id);
            if (subjectTeacher == null) return NotFound();

            await _subjectTeacherService.SoftDeleteSubjectTeacherAsync(id);
            return NoContent();
        }
    }
}
