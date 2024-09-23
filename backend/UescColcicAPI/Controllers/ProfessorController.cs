using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorCRUD _professorCRUD;

        public ProfessorController(IProfessorCRUD professorCRUD)
        {
            _professorCRUD = professorCRUD;
        }

       
        [HttpGet(Name = "GetAllProfessors")]
        public IEnumerable<Professor> Get()
        {
            return _professorCRUD.ReadAll();
        }

        [HttpGet("{id}", Name = "GetProfessorById")]
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

        [HttpPut(Name = "UpdateProfessor")] // Método de Update
        public IActionResult Update([FromBody] Professor professor)
        {
            if (professor == null)
            {
                return BadRequest("Professor data is null.");
            }

            _professorCRUD.Update(professor);
            return Ok("Professor updated successfully.");
        }

        [HttpDelete(Name = "DeleteProfessor")] // Método de Delete
        public IActionResult Delete([FromBody] Professor professor)
        {
            if (professor == null)
            {
                return BadRequest("Professor data is null.");
            }

            _professorCRUD.Delete(professor);
            return Ok("Professor deleted successfully.");
        }

        [HttpPost(Name = "CreateProfessor")] // Método de Create
        public IActionResult Create([FromBody] Professor professor)
        {
            if (professor == null)
            {
                return BadRequest("Professor data is null.");
            }

            try
            {
                _professorCRUD.Create(professor);
                return CreatedAtAction(nameof(Get), new { email = professor.Email }, professor);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Tratamento para e-mail duplicado
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating professor: {ex.Message}");
            }
        }
    }