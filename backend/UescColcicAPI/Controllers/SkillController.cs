using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillCRUD _skillCRUD;

        public SkillsController(ISkillCRUD skillCRUD)
        {
            _skillCRUD = skillCRUD;
        }

        [HttpGet(Name = "GetSkills")]
        [Authorize]
        public IEnumerable<Skill> Get()
        {
            return _skillCRUD.ReadAll();
        }

        [HttpGet("{id}", Name = "GetSkill")]
        [Authorize]
        public ActionResult<Skill> Get(int id)
        {
            try
            {
                var skill = _skillCRUD.ReadById(id);
                if (skill == null)
                {
                    return NotFound($"Skill with ID {id} not found.");
                }
                return Ok(skill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateSkill")]
        [Authorize]
        public IActionResult Update([FromBody] Skill skill)
        {
            if (skill == null)
            {
                return BadRequest("Skill data is null.");
            }

            _skillCRUD.Update(skill);
            return Ok("Skill updated successfully.");
        }

        [HttpDelete(Name = "DeleteSkill")]
        [Authorize]
        public IActionResult Delete([FromBody] Skill skill)
        {
            if (skill == null)
            {
                return BadRequest("Skill data is null.");
            }

            _skillCRUD.Delete(skill);
            return Ok("Skill deleted successfully.");
        }

        [HttpPost(Name = "CreateSkill")]
        [Authorize]
        public IActionResult Create([FromBody] Skill skill)
        {
            if (skill == null)
            {
                return BadRequest("Skill data is null.");
            }

            try
            {
                _skillCRUD.Create(skill);
                return CreatedAtAction(nameof(Get), new { id = skill.SkillId }, skill);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Tratamento para skill duplicada
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating skill: {ex.Message}");
            }
        }
    }