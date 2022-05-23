using CadastroUsuario.Application.Interfaces;
using CadastroUsuario.Application.Services;
using CadastroUsuario.Infraestructure.Context;
using CadastroUsuario.Infraestructure.Interfaces;
using CadastroUsuario.Infraestructure.RepositoryBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IParametrosDeAcessoService, ParametrosDeAcessoService>();
builder.Services.AddScoped<IParametrosDeAcessoRepository, ParametrosDeAcessoRepository>();

builder.Services.AddDbContext<ParametrosDeAcessoContext>(options =>
{
    options.UseSqlite("Data Source=C:\\Users\\joaob\\OneDrive\\Documentos\\BaseDeDados\\CadastroUsuarioProjeto.db");
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
