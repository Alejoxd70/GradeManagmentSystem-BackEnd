using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        // Get all students
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }


        // Get student by id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

            return Ok(student);
        }



        // Create a Student
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateStudent( string student_code, int userId, int attendantId )
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _studentService.CreateStudentAsync(student_code, userId, attendantId);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }

            return StatusCode(StatusCodes.Status201Created, "Student created successfully.");
        }


        // Update a Student
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult> UpdateStudent(int id,  string student_code, int userId, int attendantId )
        {

            var existingStudent = await _studentService.GetStudentByIdAsync(id);
            if (existingStudent == null) return NotFound();

            try
            {
                await _studentService.UpdateStudentAsync(id, student_code, userId, attendantId);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // Delete a student
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> SoftDeleteStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();


            try
            {
                await _studentService.SoftDeleteStudentAsync(id);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e?.Message);
            }
        }
    }
}
