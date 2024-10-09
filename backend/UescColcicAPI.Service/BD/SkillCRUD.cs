using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;
using UescColcicAPI.Services.BD.Interfaces;

namespace UescColcicAPI.Services.BD
{
    public class SkillCRUD : ISkillCRUD
    {
        private readonly MyDbContext _context;

        public SkillCRUD(MyDbContext context)
        {
            _context = context;
        }

        public void Create(Skill entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (_context.Skills.Any(x => x.title == entity.title))
            {
                throw new ArgumentException("Já existe uma Skill com esse título");
            }
            _context.Skills.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Skill> ReadAll()
        {
            return _context.Skills.ToList();
        }

        public Skill? ReadById(int id)
        {
            return _context.Skills.Find(id);
        }

        public void Update(Skill entity)
        {
            var existingSkill = _context.Skills.FirstOrDefault(x => x.SkillId == entity.SkillId);
            if (existingSkill != null)
            {
                existingSkill.title = entity.title;
                existingSkill.description = entity.description;
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Skill não encontrada");
            }
        }

        public void Delete(Skill entity)
        {
            var existingSkill = _context.Skills.Find(entity.SkillId);
            if (existingSkill != null)
            {
                _context.Skills.Remove(existingSkill);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Skill não encontrada");
            }
        }
    }
}