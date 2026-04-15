using hakaton_yz_api.Models;
using System.Linq;
namespace hakaton_yz_api.Services
{
    public class GeoCalculatorService : IGeoCalculator
    {
        public double GetDistance(int stationIdA, int stationIdB)
        {
            var stations = StationData.AllStations;
            var a = stations.FirstOrDefault(s => s.Id == stationIdA);
            var b = stations.FirstOrDefault(s => s.Id == stationIdB);
            if (a == null || b == null) return 0;
            // Dummy coordinates for demo, should be extended for real use
            double lat1 = 50.0 + stationIdA * 0.1;
            double lon1 = 30.0 + stationIdA * 0.1;
            double lat2 = 50.0 + stationIdB * 0.1;
            double lon2 = 30.0 + stationIdB * 0.1;
            return GeoCalculator.GetDistanceKm(lat1, lon1, lat2, lon2);
        }
    }
}