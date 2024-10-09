using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;

namespace UescColcicAPI.Services.BD
{
    public class StudentsCRUD : IStudentsCRUD
    {
        private readonly MyDbContext _context;

        public StudentsCRUD(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(Student entity)
        {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            if (_context.Students.Any(x => x.Email == entity.Email)) {
                throw new ArgumentException("Já existe um estudante com este email");
            }
            if (_context.Students.Any(x => x.Registration == entity.Registration)) {
                throw new ArgumentException("Já existe um estudante com este número de registro");
            }
            _context.Students.Add(entity);
            _context.SaveChanges(); // Salva as mudanças no banco de dados
        }

        public void Delete(Student entity)
        {
            var student = _context.Students.FirstOrDefault(x => x.Email == entity.Email);
            if (student != null) {
                _context.Students.Remove(student);
                _context.SaveChanges(); // Salva as mudanças
            } else {
                throw new ArgumentException("Estudante não encontrado");
            }
        }

        public IEnumerable<Student> ReadAll()
        {
            return _context.Students.ToList(); // Retorna todos os estudantes do banco de dados
        }

        public Student? ReadById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.StudentId == id);
        }

        public void Update(Student entity)
        {
            var student = _context.Students.FirstOrDefault(x => x.StudentId == entity.StudentId);
            if (student != null) {
                student.Name = entity.Name;
                student.Course = entity.Course;
                student.Bio = entity.Bio;
                student.Registration = entity.Registration;
                _context.SaveChanges(); // Salva as alterações no banco de dados
            } else {
                throw new ArgumentException("Estudante não encontrado");
            }
        }
    }
}