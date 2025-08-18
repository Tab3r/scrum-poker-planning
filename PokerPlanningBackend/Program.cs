using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PokerPlanningBackend.Application.Services;
using PokerPlanningBackend.Domain.Repositories;
using PokerPlanningBackend.Infrastructure.EntityFramework;
using PokerPlanningBackend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add Repositories
builder.Services.AddScoped<ICardRepository, CardRepositorySQLiteImpl>();

// Add services to the container.
builder.Services.AddScoped<ICardService, CardService>();

// BBDD
builder.Services.AddDbContext<PokerPlanningSQLiteContext>(options =>
    options.UseSqlite("Data Source=db/pokerplanning.db"));

// Automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Make the implicit Program class public -> can be tested in integration
public partial class Program { }
