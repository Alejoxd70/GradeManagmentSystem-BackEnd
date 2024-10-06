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
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateAssigment(string name, string description, DateOnly date, int subjectTeacherId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _assigmentService.CreateAssigmentAsync(name, description, date, subjectTeacherId);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message); ;
            }


            return StatusCode(StatusCodes.Status201Created, "Assigment created succesfully");

        }


        // Update a Assigment
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult> UpdateAssigment(int id, string name, string description, DateOnly date, int subjectTeacherId)
        {

            var existingAssigment = await _assigmentService.GetAssigmentByIdAsync(id);
            if (existingAssigment == null) return NotFound();

            try
            {
                await _assigmentService.UpdateAssigmentAsync(id, name, description, date, subjectTeacherId);
                return StatusCode(StatusCodes.Status200OK, ("Updated Successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // Delete a Assigment
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> SoftDeleteAssigment(int id)
        {
            var assigment = await _assigmentService.GetAssigmentByIdAsync(id);
            if (assigment == null) return NotFound();

            try
            {
                await _assigmentService.SoftDeleteAssigmentAsync(id);
                return StatusCode(StatusCodes.Status200OK, ("Deleted Successfully"));
            }
            catch( Exception e)
            {
                return StatusCode(404, e?.Message);
            }

        }
    }
}
