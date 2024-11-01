using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using UescColcicAPI.Middlewares;
using UescColcicAPI.Services.Auth;
using UescColcicAPI.Services.BD;
using UescColcicAPI.Services.BD.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configurar a autenticação com JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "colcic.uesc.br",
        ValidAudience = "colcic.uesc.br",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaColcicComMaisDe16Caracteres"))
    };
});

// Adicionar autorização
builder.Services.AddAuthorization();

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
builder.Services.AddScoped<IUserCRUD, UserCRUD>();
builder.Services.AddScoped<AuthService>();

// Configuração do Swagger para incluir autenticação JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UescColcicAPI", Version = "v1" });
    
    // Configuração do esquema de segurança JWT no Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira 'Bearer' seguido de um espaço e o token JWT",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Requisito de segurança para incluir o Bearer Token nas requisições
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

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

app.UseAuthentication();
app.UseAuthorization();

//app.UseMiddleware<Middleware1>();
//app.UseMiddleware<Middleware2>();
app.MapControllers();

app.Run();