using System;

namespace UescColcicAPI.Core;

public class Professor
{
    public int ProfessorId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Department { get; set; }
    public required string Bio { get; set; }

    // Navegação para projetos (um professor tem vários projetos)
    public ICollection<Project> Projects { get; set; } = new List<Project>();

    public int? UserID_FK {get; set;}
    public User user {get; set;}
}