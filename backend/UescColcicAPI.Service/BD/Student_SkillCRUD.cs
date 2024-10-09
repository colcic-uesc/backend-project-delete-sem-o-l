using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;
using UescColcicAPI.Services.BD.Interfaces;

namespace UescColcicAPI.Services.BD
{
    public class Student_SkillCRUD : IStudent_SkillCRUD
    {
        private readonly MyDbContext _context;
        private readonly IStudentsCRUD _studentsCRUD;
        private readonly ISkillCRUD _skillCRUD;

        public Student_SkillCRUD(MyDbContext context, IStudentsCRUD studentsCRUD, ISkillCRUD skillCRUD)
        {
            _context = context;
            _studentsCRUD = studentsCRUD;
            _skillCRUD = skillCRUD;
        }

        public void Create(Student_Skill entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            // Verifica se o estudante existe
            if (_studentsCRUD.ReadById(entity.StudentId_FK) == null)
            {
                throw new ArgumentException("Estudante não encontrado");
            }
            // Verifica se a skill existe
            if (_skillCRUD.ReadById(entity.SkillId_FK) == null)
            {
                throw new ArgumentException("Skill não encontrada");
            }
            // Verifica se o relacionamento já existe
            if (_context.Student_Skills.Any(x => x.SkillId_FK == entity.SkillId_FK && x.StudentId_FK == entity.StudentId_FK))
            {
                throw new ArgumentException("Já existe este relacionamento");
            }
            
            _context.Student_Skills.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Student_Skill> ReadAll()
        {
            return _context.Student_Skills.ToList();
        }

        public Student_Skill? Find(int studentId, int skillId)
        {
            return _context.Student_Skills.FirstOrDefault(x => x.SkillId_FK == skillId && x.StudentId_FK == studentId);
        }

        public void Update(Student_Skill entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            // Verifica se o estudante existe
            if (_studentsCRUD.ReadById(entity.StudentId_FK) == null)
            {
                throw new ArgumentException("Estudante não encontrado");
            }
            // Verifica se a skill existe
            if (_skillCRUD.ReadById(entity.SkillId_FK) == null)
            {
                throw new ArgumentException("Skill não encontrada");
            }

            var relationship = Find(entity.StudentId_FK, entity.SkillId_FK);
            if (relationship != null)
            {
                relationship.Weight = entity.Weight;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Relacionamento não encontrado");
            }
        }

        public void Delete(Student_Skill entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            // Verifica se o estudante existe
            if (_studentsCRUD.ReadById(entity.StudentId_FK) == null)
            {
                throw new ArgumentException("Estudante não encontrado");
            }
            // Verifica se a skill existe
            if (_skillCRUD.ReadById(entity.SkillId_FK) == null)
            {
                throw new ArgumentException("Skill não encontrada");
            }
            
            var relationship = Find(entity.StudentId_FK, entity.SkillId_FK);
            if (relationship != null)
            {
                _context.Student_Skills.Remove(relationship);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Relacionamento não encontrado");
            }
        }

        public Student_Skill? ReadById(int id)
        {
            throw new NotImplementedException();
        }
    }
}