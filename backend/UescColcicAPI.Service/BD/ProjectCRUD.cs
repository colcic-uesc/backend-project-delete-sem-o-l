using System;
using UescColcicAPI.Core;
using UescColcicAPI.Services.BD.Interfaces;

namespace UescColcicAPI.Services.BD;

public class ProjectCRUD : IProjectCRUD
{
    private readonly MyDbContext _context;

    public ProjectCRUD(MyDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Create(Project entity){
        if(entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        if(_context.Projects.Any(x => x.ProjectId == entity.ProjectId))
        {
            throw new ArgumentException("Já existe um Projeto com este Título");
        }
        _context.Projects.Add(entity);
        _context.SaveChanges();
    }
    public IEnumerable<Project> ReadAll(){
        return _context.Projects.ToList();
    }
    public Project? ReadById(int id){
        return _context.Projects.FirstOrDefault(x => x.ProjectId == id);
    }
    public void Update(Project entity){
        var prjt = _context.Projects.FirstOrDefault(x => x.ProjectId == entity.ProjectId);
        if(prjt != null){
            prjt.title = entity.title;
            prjt.description = entity.description;
            prjt.type = entity.type;
            prjt.StartDate = entity.StartDate;
            prjt.EndDate = entity.EndDate;
            _context.SaveChanges();
        } else {
            throw new ArgumentException("Projeto não encontrado");
        }
    }
    public void Delete(Project entity){
        var Project = _context.Projects.FirstOrDefault(x => x.ProjectId == entity.ProjectId);
        if (Project != null) {
            _context.Projects.Remove(Project);
            _context.SaveChanges(); // Salva as mudanças
        } else {
            throw new ArgumentException("Projeto não encontrado");
        }
    }
}