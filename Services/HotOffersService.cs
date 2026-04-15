using hakaton_yz_api.Models;

namespace hakaton_yz_api.Services
{
    public class HotOfferService
    {
        private const double MaxRouteDeviationKm = 50.0;
        private const double CostPerKm = 20.0;

        public List<HotOffer> GenerateOffers(List<Wagon> activeWagons)
        {
            var offers = new List<HotOffer>();
            var allStations = StationData.AllStations;

            var movingEmptyWagons = activeWagons.Where(w => w.IsAvailable && !string.IsNullOrEmpty(w.DestinationCity)).ToList();

            foreach (var wagon in movingEmptyWagons)
            {
                var destinationStation = allStations.FirstOrDefault(s => s.Name == wagon.DestinationCity);
                if (destinationStation == null) continue;

                double destLat = destinationStation.Type == StationType.ЦентральнийВузол ? 50.45 : 49.0; 
                double destLon = destinationStation.Type == StationType.ЦентральнийВузол ? 30.52 : 32.0; 

                double totalRouteDistance = GeoCalculator.GetDistanceKm(wagon.Latitude, wagon.Longitude, destLat, destLon);

                if (totalRouteDistance < 100) continue;

                foreach (var potentialStation in allStations)
                {
                    if (potentialStation.Name == wagon.City || potentialStation.Name == wagon.DestinationCity)
                        continue;

                    double statLat = 49.5; 
                    double statLon = 31.0; 

                    double distToStation = GeoCalculator.GetDistanceKm(wagon.Latitude, wagon.Longitude, statLat, statLon);
                    double distFromStationToDest = GeoCalculator.GetDistanceKm(statLat, statLon, destLat, destLon);

                    double deviation = (distToStation + distFromStationToDest) - totalRouteDistance;

                    if (deviation <= MaxRouteDeviationKm)
                    {
                        double savedKm = distFromStationToDest;
                        
                        double discount = (savedKm / totalRouteDistance) * 30.0;

                        discount = Math.Round(discount);

                        if (discount > 5) 
                        {
                            offers.Add(new HotOffer
                            {
                                WagonId = wagon.Id,
                                OfferCity = potentialStation.Name,
                                DiscountPercentage = discount,
                                SavedEmptyKm = Math.Round(savedKm, 1)
                            });
                        }
                    }
                }
            }

            return offers.GroupBy(o => o.OfferCity)
                         .Select(g => g.OrderByDescending(o => o.DiscountPercentage).First())
                         .ToList();
        }
    }
}
