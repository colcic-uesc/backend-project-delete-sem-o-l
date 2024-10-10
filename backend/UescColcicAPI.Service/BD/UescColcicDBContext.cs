using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public partial class MyDbContext : DbContext
{

    public DbSet<Student> Students { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Student_Skill> Student_Skills { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Project> Projects {get; set;}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student_Skill>().HasKey(
            ss => new {ss.SkillId_FK, ss.StudentId_FK}
        );

        modelBuilder.Entity<Professor>()
            .HasMany(p => p.Projects)
            .WithOne()
            .IsRequired(false);

        base.OnModelCreating(modelBuilder);   
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=/home/estevao/Documentos/Estudos_Programação/Web/WEB-24.2/backend/UescColcicAPI/UescColcicAPI.db");

        base.OnConfiguring(optionsBuilder);

    }
}