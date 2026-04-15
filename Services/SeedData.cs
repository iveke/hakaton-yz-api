// using System;
// using System.Linq;
// using hakaton_yz_api.Data;
// using hakaton_yz_api.Models;
// using Microsoft.Extensions.DependencyInjection;

// namespace hakaton_yz_api.Services
// {
//     public static class SeedData
//     {
//         public static void EnsureSeeded(IServiceProvider serviceProvider)
//         {
//             using IServiceScope scope = serviceProvider.CreateScope();
//             AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//             context.Database.EnsureCreated();

//             // Очищення старих вагонів
//             context.Wagons.RemoveRange(context.Wagons);
//             context.SaveChanges();

//             var stations = hakaton_yz_api.Models.StationData.AllStations;
//             var rand = new Random();
//             var wagons = new List<Wagon>();

//             // 300 піввагонів (OpenTop)
//             for (int i = 0; i < 300; i++)
//             {
//                 var st = stations[rand.Next(stations.Count)];
//                 wagons.Add(new Wagon
//                 {
//                     Id = Guid.NewGuid(),
//                     Latitude = 48.0 + rand.NextDouble() * 5,
//                     Longitude = 24.0 + rand.NextDouble() * 10,
//                     City = st.Name,
//                     IsAvailable = true,
//                     Type = WagonType.OpenTop,
//                     CurrentStationId = st.Id
//                 });
//             }
//             // 100 зерновозів (GrainHopper)
//             for (int i = 0; i < 100; i++)
//             {
//                 var st = stations[rand.Next(stations.Count)];
//                 wagons.Add(new Wagon
//                 {
//                     Id = Guid.NewGuid(),
//                     Latitude = 48.0 + rand.NextDouble() * 5,
//                     Longitude = 24.0 + rand.NextDouble() * 10,
//                     City = st.Name,
//                     IsAvailable = true,
//                     Type = WagonType.GrainHopper,
//                     CurrentStationId = st.Id
//                 });
//             }
//             // 50 цементовозів (CementWagon)
//             for (int i = 0; i < 50; i++)
//             {
//                 var st = stations[rand.Next(stations.Count)];
//                 wagons.Add(new Wagon
//                 {
//                     Id = Guid.NewGuid(),
//                     Latitude = 48.0 + rand.NextDouble() * 5,
//                     Longitude = 24.0 + rand.NextDouble() * 10,
//                     City = st.Name,
//                     IsAvailable = true,
//                     Type = WagonType.CementWagon,
//                     CurrentStationId = st.Id
//                 });
//             }
//             context.Wagons.AddRange(wagons);
//             context.SaveChanges();
//                         City = "Ternopil",
//                         IsAvailable = true,
//                     },
//                     new Wagon
//                     {
//                         Id = Guid.NewGuid(),
//                         Latitude = 46.9750,
//                         Longitude = 31.9946,
//                         City = "Mykolaiv",
//                         IsAvailable = true,
//                     },
//                     new Wagon
//                     {
//                         Id = Guid.NewGuid(),
//                         Latitude = 48.6208,
//                         Longitude = 22.2879,
//                         City = "Uzhhorod",
//                         IsAvailable = true,
//                     }
//                 );
//                 context.SaveChanges();
//             }
//         }
//     }
// }
