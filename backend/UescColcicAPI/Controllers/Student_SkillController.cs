using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class StudentSkillsController : ControllerBase
    {
        private readonly IStudent_SkillCRUD _studentSkillCRUD;

        public StudentSkillsController(IStudent_SkillCRUD studentSkillCRUD)
        {
            _studentSkillCRUD = studentSkillCRUD;
        }

        // Método para obter todos os relacionamentos de Student_Skill
        [HttpGet(Name = "GetStudentSkills")]
        [Authorize]
        public IEnumerable<Student_Skill> Get()
        {
            return _studentSkillCRUD.ReadAll();
        }

        // Método Get
        [HttpGet("{studentId}/{skillId}", Name = "GetStudentSkill")]
        [Authorize]
        public ActionResult<Student_Skill> Get(int studentId, int skillId)
        {
            try
            {
                // Obter todos os relacionamentos de Student_Skill
                var studentSkills = _studentSkillCRUD.ReadAll();

                // Filtrar o relacionamento específico usando LINQ
                var studentSkill = studentSkills.FirstOrDefault(x => x.StudentId_FK == studentId && x.SkillId_FK == skillId);

                if (studentSkill == null)
                {
                    return NotFound($"StudentSkill with Student ID {studentId} and Skill ID {skillId} not found.");
                }

                return Ok(studentSkill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Método Update
        [HttpPut(Name = "UpdateStudentSkill")]
        [Authorize]
        public IActionResult Update([FromBody] Student_Skill studentSkill)
        {
            if (studentSkill == null)
            {
                return BadRequest("StudentSkill data is null.");
            }

            try
            {
                _studentSkillCRUD.Update(studentSkill);
                return Ok("StudentSkill updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Tratamento de exceção
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating StudentSkill: {ex.Message}");
            }
        }

        // Método Delete
        [HttpDelete(Name = "DeleteStudentSkill")]
        [Authorize]
        public IActionResult Delete([FromBody] Student_Skill studentSkill)
        {
            if (studentSkill == null)
            {
                return BadRequest("StudentSkill data is null.");
            }

            try
            {
                _studentSkillCRUD.Delete(studentSkill);
                return Ok("StudentSkill deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Tratamento de exceção
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting StudentSkill: {ex.Message}");
            }
        }

        // Método Create
        [HttpPost(Name = "CreateStudentSkill")]
        [Authorize]
        public IActionResult Create([FromBody] Student_Skill studentSkill)
        {
            if (studentSkill == null)
            {
                return BadRequest("StudentSkill data is null.");
            }

            try
            {
                _studentSkillCRUD.Create(studentSkill);
                return CreatedAtAction(nameof(Get), new { studentId = studentSkill.StudentId_FK, skillId = studentSkill.SkillId_FK }, studentSkill);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Tratamento de exceção
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating StudentSkill: {ex.Message}");
            }
        }
    }