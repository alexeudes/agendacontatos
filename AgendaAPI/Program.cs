﻿using AgendaAPI.Data;
using AgendaAPI.Data.Repositories;
using AgendaAPI.Data.Repositories.Interfaces;
using AgendaAPI.Mappers;
using AgendaAPI.Services;
using AgendaAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection

builder.Services.AddScoped<IAgendaService, AgendaService>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();

#endregion

builder.Services.AddDbContext<DataContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApiDatabase"));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();

