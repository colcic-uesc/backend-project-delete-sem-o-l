using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorCRUD _professorCRUD;

        public ProfessorController(IProfessorCRUD professorCRUD)
        {
            _professorCRUD = professorCRUD;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {
            var professors = _professorCRUD.ReadAll();
            return Ok(professors);
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> Get(int id)
        {
            try
            {
                var professor = _professorCRUD.ReadById(id);
                if (professor == null)
                {
                    return NotFound($"Professor with ID {id} not found.");
                }
                return Ok(professor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Professor professor)
        {
            if (professor == null)
            {
                return BadRequest("Professor data is null.");
            }

            try
            {
                _professorCRUD.Create(professor);
                return CreatedAtAction(nameof(Get), new { id = professor.ProfessorId }, professor);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating professor: {ex.Message}. Inner Exception: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Professor professor)
        {
            if (professor == null)
            {
                return BadRequest("Professor data is null.");
            }

            if (id != professor.ProfessorId)
            {
                return BadRequest("Professor ID mismatch.");
            }

            try
            {
                _professorCRUD.Update(professor);
                return Ok("Professor updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating professor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var professor = _professorCRUD.ReadById(id);
                if (professor == null)
                {
                    return NotFound($"Professor with ID {id} not found.");
                }

                _professorCRUD.Delete(professor);
                return Ok("Professor deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting professor: {ex.Message}");
            }
        }
    }
}