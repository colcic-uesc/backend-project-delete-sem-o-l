using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
 
namespace UescColcicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Student_SkillsController : ControllerBase
    {
        private readonly IStudent_SkillCRUD _studentSkillCRUD;

        public Student_SkillsController(IStudent_SkillCRUD studentSkillCRUD)
        {
            _studentSkillCRUD = studentSkillCRUD;
        }

        [HttpGet(Name = "GetStudentSkills")]
        public IEnumerable<Student_Skill> Get()
        {
            return _studentSkillCRUD.ReadAll();
        }

        [HttpGet("{studentId}/{skillId}", Name = "GetStudentSkill")]
        public ActionResult<Student_Skill> Get(int studentId, int skillId)
        {
            try
            {
                var studentSkill = _studentSkillCRUD.Find(studentId, skillId);
                if (studentSkill == null)
                {
                    return NotFound($"Relationship between Student ID {studentId} and Skill ID {skillId} not found.");
                }
                return Ok(studentSkill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateStudentSkill")]
        public IActionResult Update([FromBody] Student_Skill studentSkill)
        {
            if (studentSkill == null)
            {
                return BadRequest("Student_Skill data is null.");
            }

            try
            {
                _studentSkillCRUD.Update(studentSkill);
                return Ok("Student_Skill updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete(Name = "DeleteStudentSkill")]
        public IActionResult Delete([FromBody] Student_Skill studentSkill)
        {
            if (studentSkill == null)
            {
                return BadRequest("Student_Skill data is null.");
            }

            try
            {
                _studentSkillCRUD.Delete(studentSkill);
                return Ok("Student_Skill deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost(Name = "CreateStudentSkill")]
        public IActionResult Create([FromBody] Student_Skill studentSkill)
        {
            if (studentSkill == null)
            {
                return BadRequest("Student_Skill data is null.");
            }

            try
            {
                _studentSkillCRUD.Create(studentSkill);
                return CreatedAtAction(nameof(Get), new { studentId = studentSkill.StudentId_FK, skillId = studentSkill.SkillId_FK }, studentSkill);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Tratamento para duplicação de relacionamento
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating relationship: {ex.Message}");
            }
        }
    }
}