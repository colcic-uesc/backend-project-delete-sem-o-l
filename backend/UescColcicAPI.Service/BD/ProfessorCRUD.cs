using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class ProfessorCRUD : IProfessorCRUD
{
    private static readonly List<Professor> Professor = new()
   {
      new Professor { ProfessorId = 1, Name = "Helder", Email = "helder.cic@uesc.br", Department = "ababa", Bio = "ababa" },
      new Professor { ProfessorId = 2, Name = "Hamilton", Email = "hamilton.cic@uesc.br", Department = "ababa", Bio = "ababa" },
      new Professor { ProfessorId = 3, Name = "Marta", Email = "marta.cic@uesc.br", Department = "ababa", Bio = "ababa" },
      new Professor { ProfessorId = 4, Name = "Esbel", Email = "esbel.cic@uesc.br", Department = "ababa", Bio = "ababa" }
   };

    public void Create(Professor entity)
    {
        if (entity == null) {
            throw new ArgumentNullException("entity");
        }
        if (Professor.Any(x => x.Email == entity.Email)) {
            throw new ArgumentException("Já existe um professor com este email");
        }
        Professor.Add(entity);
    }

    public void Delete(Professor entity)
    {
        var remove = Professor.RemoveAll(x => x.Email == entity.Email);
        if (remove == 0) {
            throw new ArgumentException("Professor não encontrado");
        }
    }

    public void Update(Professor entity)
    {
        var student = Professor.FirstOrDefault(x => x.Email == entity.Email);
        if (student is not null) {
            student.Name = entity.Name;
        } else {
            throw new ArgumentException("Professor não encontrado");
        }
    }

    IEnumerable<Professor> IBaseCRUD<Professor>.ReadAll()
    {
        return Professor;
    }

    public Professor? ReadById(int id)
    {
        var professor = this.Find(id);
        return professor;
    }

    private Professor? Find(string email)
    {
        return Professor.FirstOrDefault(x => x.Email == email);
    }

    private Professor? Find(int id)
    {
        return Professor.FirstOrDefault(x => x.ProfessorId == id);
    }
}