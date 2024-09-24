using System.Buffers;
using UescColcicAPI.Core;
using UescColcicAPI.Services.BD.Interfaces;

namespace UescColcicAPI.Services.BD;

public class Student_SkillCRUD : IStudent_SkillCRUD
{
    private static readonly List<Student_Skill> Student_Skill = new (){
    
    };
      public void Create(Student_Skill entity)
      {
        if(entity == null){
          throw new ArgumentNullException("entity");
        }
        if(Student_Skill.Any(x => (x.SkillId_FK == entity.SkillId_FK && x.StudentId_FK == entity.StudentId_FK)))
        {
          throw new ArgumentException("Já existe este relacionamento");
        }
        Student_Skill.Add(entity);
      }
      
      public IEnumerable<Student_Skill> ReadAll()
      {
        return SS;
      }
      
      public Student_Skill? ReadById(int id)
      {
        var SS = this.Find(id);
        return SS;
      }
      
      public void Update(Student_Skill entity) //Talvez o update seja na mesma forma que o delete
      {
        var SS = Student_Skill.FirstOrDefault(x => (x.SkillId_FK == entity.SkillId_FK && x.StudentId_FK == entity.StudentId_FK));
        if (SS != null)
        {
          SS.Weight = entity.Weight;
        } else {
          throw new ArgumentException("Não encontrado");
        }
      }

      /*
      Sobre o Delete, Fiz assim pra apagar o relacionamento.

      O que eu acho: Deve-se alterar o Delete tanto de Student quanto de Skill
      Assim, quando for apagar um desses objetos, deletar tbm o relacionamento.
      Seja lá qual for a regra de negocio desse troço.
      
      */
      
      public void Delete(Student_Skill entity) 
      {
        var SS = Student_Skill.FirstOrDefault(x => (x.SkillId_FK == entity.SkillId_FK && x.StudentId_FK == entity.StudentId_FK));
        if (SS != null) {
            Student_Skill.Remove(SS);
        } else {
            throw new ArgumentException("Relacionamento não encontrado.")
        }
      }

      public Student_Skill? Find(int id){
        return Student_Skill.FirstOrDefault(x => (x.SkillId_FK == entity.SkillId_FK && x.StudentId_FK == entity.StudentId_FK));
      }
}
