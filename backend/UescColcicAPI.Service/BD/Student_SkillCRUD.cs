using System.Buffers;
using UescColcicAPI.Core;
using UescColcicAPI.Services.BD.Interfaces;

namespace UescColcicAPI.Services.BD;

public class Student_SkillCRUD : IStudent_SkillCRUD
{
    private readonly IStudentsCRUD _studentsCRUD;
    private readonly ISkillCRUD _skillCRUD;

    public Student_SkillCRUD(IStudentsCRUD studentsCRUD, ISkillCRUD skillCRUD)
    {
        _studentsCRUD = studentsCRUD;
        _skillCRUD = skillCRUD;
    }
    private static readonly List<Student_Skill> Student_Skill = new()
    {
        new Student_Skill { StudentId_FK = 1, SkillId_FK = 1, Weight = 5 },
        new Student_Skill { StudentId_FK = 1, SkillId_FK = 2, Weight = 4 },
        new Student_Skill { StudentId_FK = 2, SkillId_FK = 1, Weight = 3 },
        new Student_Skill { StudentId_FK = 2, SkillId_FK = 3, Weight = 4 }
    };
    
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
        if (Student_Skill.Any(x => x.SkillId_FK == entity.SkillId_FK && x.StudentId_FK == entity.StudentId_FK))
        {
            throw new ArgumentException("Já existe este relacionamento");
        }
        
        Student_Skill.Add(entity);
    }
    
    public IEnumerable<Student_Skill> ReadAll()
    {
        return Student_Skill;
    }

    public Student_Skill? Find(int studentId, int skillId)
    {
        return Student_Skill.FirstOrDefault(x => x.SkillId_FK == skillId && x.StudentId_FK == studentId);
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
            Student_Skill.Remove(relationship);
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