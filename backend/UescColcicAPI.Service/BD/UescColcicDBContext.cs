using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;

public partial class MyDbContext : DbContext
{

    public DbSet<Student> Students { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Student_Skill> Student_Skills { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student_Skill>().HasKey(
            ss => new {ss.SkillId_FK, ss.StudentId_FK}
        );
        base.OnModelCreating(modelBuilder);        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=/home/rorizdavioliveira/UESC/colcic_web_2024_2/backend/UescColcicAPI/UescColcicAPI.db");

        base.OnConfiguring(optionsBuilder);

    }
}