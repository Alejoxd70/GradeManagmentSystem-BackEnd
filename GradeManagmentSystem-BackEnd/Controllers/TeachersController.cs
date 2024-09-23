using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeManagmentSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        // Get all teachers
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }


        // Get teacher by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null) return NotFound();

            return Ok(teacher);
        }



        // Create a Teacher
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTeacher([FromBody] Teacher teacher)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _teacherService.CreateTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }


        // Update a Teacher
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Teacher teacher)
        {
            if (id != teacher.Id) return BadRequest();

            var existingTeacher = await _teacherService.GetTeacherByIdAsync(id);
            if (existingTeacher == null) return NotFound();

            await _teacherService.UpdateTeacherAsync(teacher);
            return NoContent();
        }

        // Delete a teacher
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> SoftDeleteTeacher(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null) return NotFound();

            await _teacherService.SoftDeleteTeacherAsync(id);
            return NoContent();
        }
    }
}
