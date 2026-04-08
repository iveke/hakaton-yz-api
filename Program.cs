using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using hakaton_yz_api.Services;
using hakaton_yz_api.Data;
using hakaton_yz_api.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure the database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Register the AlgorithmService
builder.Services.AddScoped<AlgorithmService>();

WebApplication app = builder.Build();

// Seed data
SeedData.EnsureSeeded(app.Services);

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
