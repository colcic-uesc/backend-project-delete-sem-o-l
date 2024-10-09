using UescColcicAPI.Services.BD;
using UescColcicAPI.Services.BD.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Adiciona o DbContext e configura a string de conexão (usando SQLite como exemplo)
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona as implementações dos serviços
builder.Services.AddScoped<IStudentsCRUD, StudentsCRUD>();
// builder.Services.AddScoped<IProfessorCRUD, ProfessorCRUD>();
builder.Services.AddScoped<ISkillCRUD, SkillCRUD>();
// builder.Services.AddScoped<IStudent_SkillCRUD, Student_SkillCRUD>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();