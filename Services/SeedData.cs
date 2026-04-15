using System;
using System.Linq;
using hakaton_yz_api.Data;
using hakaton_yz_api.Models;
using Microsoft.Extensions.DependencyInjection;

namespace hakaton_yz_api.Services
{
    public static class SeedData
    {
        public static void EnsureSeeded(IServiceProvider serviceProvider)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            if (!context.Wagons.Any())
            {
                context.Wagons.AddRange(
                    new Wagon
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 50.4501,
                        Longitude = 30.5234,
                        City = "Kyiv",
                        IsAvailable = true,
                    },
                    new Wagon
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 49.8397,
                        Longitude = 24.0297,
                        City = "Lviv",
                        IsAvailable = true,
                    },
                    new Wagon
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 46.4825,
                        Longitude = 30.7233,
                        City = "Odesa",
                        IsAvailable = true,
                    },
                    new Wagon
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 48.4647,
                        Longitude = 35.0462,
                        City = "Dnipro",
                        IsAvailable = true,
                    },
                    new Wagon
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 49.9935,
                        Longitude = 36.2304,
                        City = "Kharkiv",
                        IsAvailable = true,
                    },
                    new Wagon
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 47.8388,
                        Longitude = 35.1396,
                        City = "Zaporizhzhia",
                        IsAvailable = true,
                    },
                    new Wagon
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 49.2331,
                        Longitude = 28.4682,
                        City = "Vinnytsia",
                        IsAvailable = true,
                    },
                    new Wagon
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 49.5535,
                        Longitude = 25.5948,
                        City = "Ternopil",
                        IsAvailable = true,
                    },
                    new Wagon
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 46.9750,
                        Longitude = 31.9946,
                        City = "Mykolaiv",
                        IsAvailable = true,
                    },
                    new Wagon
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 48.6208,
                        Longitude = 22.2879,
                        City = "Uzhhorod",
                        IsAvailable = true,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
