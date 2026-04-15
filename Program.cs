using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using hakaton_yz_api.Services;
using hakaton_yz_api.Data;
using hakaton_yz_api.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Enable CORS for all origins, methods, and headers
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddControllers();

// Configure the database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Register the AlgorithmService
builder.Services.AddScoped<ICostMatrixService, CostMatrixService>();
builder.Services.AddScoped<IInterceptEngine, InterceptEngine>();
builder.Services.AddScoped<HotOfferService>();
builder.Services.AddScoped<IGeoCalculator, GeoCalculatorService>();
builder.Services.AddScoped<AlgorithmService>();

WebApplication app = builder.Build();


// Seed data
// SeedData.EnsureSeeded(app.Services); // вимкнено після початкового наповнення

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
