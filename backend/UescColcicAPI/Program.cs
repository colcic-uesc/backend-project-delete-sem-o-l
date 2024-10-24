using UescColcicAPI.Services.BD;
using UescColcicAPI.Services.BD.Interfaces;
using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Adiciona o DbContext e configura a string de conexão (usando SQLite como exemplo)
builder.Services.AddDbContext<MyDbContext>();

// Adiciona as implementações dos serviços
builder.Services.AddScoped<IStudentsCRUD, StudentsCRUD>();
builder.Services.AddScoped<IProfessorCRUD, ProfessorCRUD>();
builder.Services.AddScoped<ISkillCRUD, SkillCRUD>();
builder.Services.AddScoped<IStudent_SkillCRUD, Student_SkillCRUD>();
builder.Services.AddScoped<IProjectCRUD, ProjectCRUD>();

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

app.UseMiddleware<Middleware1>();
app.UseMiddleware<Middleware2>();
app.MapControllers();

app.Run();