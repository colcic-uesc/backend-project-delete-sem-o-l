using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;

namespace UescColcicAPI.Services.BD;

public class ProfessorCRUD : IProfessorCRUD
{
    private readonly MyDbContext _context;

    public ProfessorCRUD(MyDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Create(Professor entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        if (_context.Professors.Any(x => x.Email == entity.Email))
        {
            throw new ArgumentException("Já existe um professor com este email");
        }
        _context.Professors.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Professor entity)
    {
        var professor = _context.Professors.FirstOrDefault(x => x.Email == entity.Email);
        if (professor != null)
        {
            _context.Professors.Remove(professor);
            _context.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Professor não encontrado");
        }
    }

    public void Update(Professor professor)
    {
        var existingProfessor = _context.Professors.Include(p => p.Projects)
                                                   .FirstOrDefault(p => p.ProfessorId == professor.ProfessorId);

        if (existingProfessor != null)
        {
            // Atualizar dados do professor
            existingProfessor.Name = professor.Name;
            existingProfessor.Email = professor.Email;
            existingProfessor.Department = professor.Department;
            existingProfessor.Bio = professor.Bio;

            // Se necessário, atualizar também os projetos do professor
            existingProfessor.Projects = professor.Projects;

            _context.SaveChanges();
        }
    }

    IEnumerable<Professor> IBaseCRUD<Professor>.ReadAll()
    {
        return _context.Professors;
    }

    public Professor? ReadById(int id)
    {
        return _context.Professors.FirstOrDefault(x => x.ProfessorId == id);
    }

    private Professor? Find(string email)
    {
        return _context.Professors.FirstOrDefault(x => x.Email == email);
    }

    private Professor? Find(int id)
    {
        return _context.Professors.FirstOrDefault(x => x.ProfessorId == id);
    }
}