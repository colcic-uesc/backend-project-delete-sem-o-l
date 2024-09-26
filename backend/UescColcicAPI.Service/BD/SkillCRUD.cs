using System.Buffers;
using UescColcicAPI.Core;
using UescColcicAPI.Services.BD.Interfaces;

namespace UescColcicAPI.Services.BD;

public class SkillCRUD : ISkillCRUD
{
      private static readonly List<Skill> Skill = new (){

      };
      public void Create(Skill entity)
      {
        if(entity == null){
          throw new ArgumentNullException("entity");
        }
        if(Skill.Any(x => x.title == entity.title))
        {
          throw new ArgumentException("Já existe esta Skill com esse título");
        }
        Skill.Add(entity);
      }
      
      public IEnumerable<Skill> ReadAll()
      {
        return Skill;
      }
      
      public Skill? ReadById(int id)
      {
        var Skill = this.Find(id);
        return Skill;
      }
      
      public void Update(Skill entity)
      {
        var Skills = Skill.FirstOrDefault(x => x.SkillId == entity.SkillId);
        if (Skills != null)
        {
          Skills.title = entity.title;
          Skills.description = entity.description;
        } else {
          throw new ArgumentException("Skill não encontrada");
        }
      }
      
      public void Delete(Skill entity)
      {
        var remove = Skill.RemoveAll(x => x.SkillId == entity.SkillId);
        if (remove == 0) {
            throw new ArgumentException("Skill não encontrado");
        }
      }

      public Skill? Find(int id){
        return Skill.FirstOrDefault(x => x.SkillId == id);
      }
}