using BackAgendaDeContactos;
using BackAgendaDeContactos.Models;
using Microsoft.EntityFrameworkCore;

using BackAgendaDeContactos.Services.Clases;
using BackAgendaDeContactos.Services.Interfaces;

using AutoMapper;
using BackAgendaDeContactos.DTOs;
using BackAgendaDeContactos.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AgendaDeContactosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IGrupoService,GrupoService>();
builder.Services.AddScoped<IContactoService, ContactoService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
    });
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

app.UseCors("NuevaPolitica");

app.Run();
