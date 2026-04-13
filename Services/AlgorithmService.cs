using System;
using System.Collections.Generic;
using System.Linq;
using hakaton_yz_api.Models;

namespace hakaton_yz_api.Services
{
    public class AlgorithmService
    {
        private const decimal CostPerKmEmpty = 20.0m;
        private const double AverageSpeedKmPerHour = 50.0;

        private readonly IDistanceService _distanceService;
        public AlgorithmService(IDistanceService distanceService)
        {
            _distanceService = distanceService;
        }

        public IEnumerable<object> SuggestBestWagons(List<Wagon> availableWagons, Shipment shipment)
        {
            if (availableWagons == null || !availableWagons.Any())
            {
                return null;
            }

            // TODO: implement optimization algorithm

            // Mock logic: Take up to 3 wagons, sort them by fake distances
            var suggestions = new List<WagonSuggestion>();

            foreach (var wagon in availableWagons)
            {
                double distance = _distanceService.GetDistanceInKm(
                    wagon.City, shipment.FromCity,
                    wagon.Latitude, wagon.Longitude,
                    shipment.FromLat, shipment.FromLon
                );
                decimal emptyRunCost = (decimal)distance * CostPerKmEmpty;
                double hoursInTransit = distance / AverageSpeedKmPerHour;
                int daysInTransit = (int)Math.Ceiling(hoursInTransit / 24.0);

                suggestions.Add(new WagonSuggestion
                {
                    WagonId = wagon.Id,
                    CurrentCity = wagon.City,
                    DistanceKm = Math.Round(distance, 2),
                    EmptyRunCost = Math.Round(emptyRunCost, 2),
                    EstimatedDaysInTransit = daysInTransit == 0 ? 1 : daysInTransit
                });
            }

            return suggestions
                .OrderBy(s => s.DistanceKm)
                .Take(topCount);
        }
    }
}
