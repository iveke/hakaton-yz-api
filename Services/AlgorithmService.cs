using System;
using System.Collections.Generic;
using System.Linq;
using hakaton_yz_api.Models;

namespace hakaton_yz_api.Services
{
    public class AlgorithmService
    {
        public IEnumerable<object>? SuggestBestWagons(List<Wagon> availableWagons, Shipment shipment)
        {
            if (availableWagons == null || !availableWagons.Any())
            {
                return null;
            }

            // TODO: implement optimization algorithm
            
            // Mock logic: Take up to 3 wagons, sort them by fake distances
            return availableWagons
                .Select((w, index) => new
                {
                    wagonId = w.Id,
                    wagonCity = w.City,
                    shipmentFromCity = shipment.FromCity,
                    shipmentToCity = shipment.ToCity,
                    distanceToLoad = 100 + (index * 50),
                    timeToLoad = 2 + index,
                    distanceToUnload = 300 + (index * 10),
                    timeToUnload = 5 + index,
                    estimatedArrivalToLoad = DateTime.UtcNow.AddHours(2 + index),
                    estimatedArrivalToUnload = DateTime.UtcNow.AddHours((2 + index) + (5 + index))
                })
                .OrderBy(x => x.distanceToLoad)
                .Take(3)
                .ToList();
        }
    }
}
