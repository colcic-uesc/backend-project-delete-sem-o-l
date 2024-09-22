using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public class StudentsCRUD : IStudentsCRUD
{
    private static readonly List<Student> Students = new()
   {
      new Student { StudentId = 1, Name = "Douglas", Email = "douglas.cic@uesc.br" },
      new Student { StudentId = 2, Name = "Estevão", Email = "estevao.cic@uesc.br" },
      new Student { StudentId = 3, Name = "Gabriel", Email = "gabriel.cic@uesc.br" },
      new Student { StudentId = 4, Name = "Gabriela", Email = "gabriela.cic@uesc.br" }
   };
    public void Create(Student entity) // Método para criar um estudante novo
    {
        if (entity == null) {
            throw new ArgumentNullException("entity");
        }

        // Verificar se já existe um estudante com o mesmo email
        if (Students.Any(x => x.Email == entity.Email)) {
            throw new ArgumentException("Já existe um estudante com este email");
        }

        Students.Add(entity);
    }

    public void Delete(Student entity) // Método para excluir um estudante
    {
        var remove = Students.RemoveAll(x => x.Email == entity.Email);
        if (remove == 0) {
            throw new ArgumentException("Estudante não encontrado");
        }
    }

    public IEnumerable<Student> ReadAll()
    {
        return Students;
    }

    public Student? ReadById(int id)
    {
        var student = this.Find(id);
        return student;
    }

    public void Update(Student entity) // Método para atualizar um estudante já existente
    {
        var student = Students.FirstOrDefault(x => x.Email == entity.Email);
        if (student is not null) {
            student.Name = entity.Name;
        } else {
            throw new ArgumentException("Estudante não encontrado");
        }
    }

    private Student? Find(string email)
    {
        return Students.FirstOrDefault(x => x.Email == email);
    }

    private Student? Find(int id)
    {
        return Students.FirstOrDefault(x => x.StudentId == id);
    }

}