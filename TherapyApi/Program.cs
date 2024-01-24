using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TherapyApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PatientContext>(opt =>
    opt.UseInMemoryDatabase("TherapyApp"));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program)); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
