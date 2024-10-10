using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UescColcicAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentsCRUD _studentsCRUD;

    public StudentsController(IStudentsCRUD studentsCRUD)
    {
        _studentsCRUD = studentsCRUD;
    }
    
    [HttpGet(Name = "GetStudents")]
    public IEnumerable<Student> Get()
    {
        return _studentsCRUD.ReadAll();
    }

    [HttpGet("{id}", Name = "GetStudent")]
    public ActionResult<Student> Get(int id)
    {
        try
        {
            var student = _studentsCRUD.ReadById(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(student);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateStudent")] // Método de Update
    public IActionResult Update([FromBody] Student student)
    {
        if (student == null)
        {
            return BadRequest("Student data is null.");
        }

        _studentsCRUD.Update(student);
        return Ok("Student updated successfully.");
    }

    [HttpDelete(Name = "DeleteStudent")] // Método de Delete
    public IActionResult Delete([FromBody] Student student)
    {
        if (student == null)
        {
            return BadRequest("Student data is null.");
        }

        _studentsCRUD.Delete(student);
        return Ok("Student deleted successfully.");
    }

    [HttpPost(Name = "CreateStudent")] // Método de Create
    public IActionResult Create([FromBody] Student student)
    {
        if (student == null)
        {
            return BadRequest("Student data is null.");
        }

        try
        {
            _studentsCRUD.Create(student);
            return CreatedAtAction(nameof(Get), new { email = student.Email }, student);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message); // Tratamento para e-mail duplicado
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating student: {ex.Message}");
        }
    }
}