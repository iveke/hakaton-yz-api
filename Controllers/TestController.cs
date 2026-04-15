using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using hakaton_yz_api.Models;
using hakaton_yz_api.Services;

namespace hakaton_yz_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("offers")]
        public IActionResult TestHotOffers()
        {
            // 1. Ініціалізуємо наш сервіс
            var offerService = new HotOfferService();

            // 2. Створюємо тестові "фейкові" вагони
            var mockWagons = new List<Wagon>
            {
                new Wagon
                {
                    Id = Guid.NewGuid(),
                    City = "Львів-Головний",
                    Latitude = 49.8397,
                    Longitude = 24.0297,
                    DestinationCity = "Дніпро-Головний", // Їде далеко
                    IsAvailable = true
                },
                new Wagon
                {
                    Id = Guid.NewGuid(),
                    City = "Дарниця",
                    Latitude = 50.4315,
                    Longitude = 30.6535,
                    DestinationCity = "Київ-Пасажирський", // Їде надто близько (< 100 км), має бути проігнорований
                    IsAvailable = true
                },
                new Wagon
                {
                    Id = Guid.NewGuid(),
                    City = "Одеса-Головна", 
                    // Немає DestinationCity, значить просто стоїть. Має бути проігнорований.
                    IsAvailable = true
                }
            };

            // 3. Запускаємо метод
            var results = offerService.GenerateOffers(mockWagons);

            // 4. Повертаємо результат у форматі JSON
            return Ok(new
            {
                Message = "Алгоритм відпрацював",
                TotalOffersGenerated = results.Count,
                Data = results
            });
        }
    }
}