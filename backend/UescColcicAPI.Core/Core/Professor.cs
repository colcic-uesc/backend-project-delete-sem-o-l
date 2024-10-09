using System;

namespace UescColcicAPI.Core;

public class Professor
{
    public int ProfessorId { get; set; }
    public required string Name { get; set; } 
    public required string Email { get; set; }
    public required string Department { get; set; }
    public required string Bio { get; set; }
    public required IEnumerable<int> Projects_FK { get; set; }
}