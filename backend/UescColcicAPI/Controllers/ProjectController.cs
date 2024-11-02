using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace UescColcicAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
  private readonly IProjectCRUD _projectsCRUD;

        public ProjectController(IProjectCRUD ProjectCRUD)
        {
            _projectsCRUD = ProjectCRUD;
        }
       
        [HttpGet(Name = "GetProject")]
        [Authorize]
        public IEnumerable<Project> Get()
        {
            return _projectsCRUD.ReadAll();
        }

        [HttpGet("{id}", Name = "GetProject{id}")]
        [Authorize]
        public ActionResult<Project> Get(int id)
        {
            try
            {
                var Project = _projectsCRUD.ReadById(id);
                if (Project == null)
                {
                    return NotFound($"Project with ID {id} not found.");
                }
                return Ok(Project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut(Name = "UpdateProject")] // Método de Update
        [Authorize]
        public IActionResult Update([FromBody] Project Project)
        {
            if (Project == null)
            {
                return BadRequest("Project data is null.");
            }

            _projectsCRUD.Update(Project);
            return Ok("Project updated successfully.");
        }

        [HttpDelete(Name = "DeleteProject")] // Método de Delete
        [Authorize]
        public IActionResult Delete([FromBody] Project Project)
        {
            if (Project == null)
            {
                return BadRequest("Project data is null.");
            }

            _projectsCRUD.Delete(Project);
            return Ok("Project deleted successfully.");
        }

        [HttpPost(Name = "CreateProject")] // Método de Create]
        [Authorize]
        public IActionResult Create([FromBody] Project Project)
        {
            if (Project == null)
            {
                return BadRequest("Project data is null.");
            }

            try
            {
                _projectsCRUD.Create(Project);
                return CreatedAtAction(nameof(Get), new { title = Project.title }, Project);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Tratamento para título duplicado
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating Project: {ex.Message}");
            }
        }
}
