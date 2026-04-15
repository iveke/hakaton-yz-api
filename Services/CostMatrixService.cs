using System;
using System.Collections.Generic;
using hakaton_yz_api.Models;

namespace hakaton_yz_api.Services
{
    public class CostMatrixService: ICostMatrixService
    {
        private const decimal CostPerKm = 20.0m;
        private const double KmPerDay = 300.0;

        public List<CostEdge> CostMatrix (List<Wagon> wagons, List<Shipment> pendingShipments){
            var costs = new List<CostEdge>();
            foreach(var wagon in wagons){
                foreach(var shipment in pendingShipments){
                    var distance = CalculateDistance(wagon.Latitude, wagon.Longitude, shipment.FromLat, shipment.FromLon);
                    var cost = (decimal)distance * CostPerKm;
                    double daysNeeded = distance / KmPerDay;
                    DateTime estimatedArrival = DateTime.UtcNow.AddDays(daysNeeded);
                    decimal latenessPenalty = 0;
                    if(estimatedArrival > shipment.Deadline){
                        latenessPenalty = (decimal)(estimatedArrival - shipment.Deadline).TotalDays * 50000;   
                    }
                    costs.Add(new CostEdge
                    {
                        WagonId = wagon.Id,
                        ShipmentId = shipment.Id,
                        DistanceKm = distance,
                        TotalCost = cost + latenessPenalty
                    });

                }
                
            }
            return costs;
        }
        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371;
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            var a = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) * Math.Pow(Math.Sin(dLon / 2), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c* 1.2;
        }
        private double ToRadians(double angle)
        {
            return angle * (Math.PI / 180);
        }
