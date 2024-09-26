using System.Buffers;
using UescColcicAPI.Core;
using UescColcicAPI.Services.BD.Interfaces;

namespace UescColcicAPI.Services.BD;

public class SkillCRUD : ISkillCRUD
{
    private static readonly List<Skill> Skill = new ()
    {
        new Skill { SkillId = 1, title = "Programação C#", description = "Conhecimento em desenvolvimento de software usando C#" },
        new Skill { SkillId = 2, title = "Banco de Dados SQL", description = "Experiência em gerenciamento e consultas SQL" },
        new Skill { SkillId = 3, title = "Desenvolvimento Web", description = "Habilidades em desenvolvimento de aplicações web com HTML, CSS e JavaScript" },
        new Skill { SkillId = 4, title = "Machine Learning", description = "Conhecimento em técnicas e algoritmos de aprendizado de máquina" },
        new Skill { SkillId = 5, title = "Segurança da Informação", description = "Noções de segurança da informação e proteção de dados" }
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