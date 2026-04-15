using System;
using System.Collections.Generic;
using System.Linq;
using hakaton_yz_api.Models;

namespace hakaton_yz_api.Services
{
    public interface IInterceptEngine
    {
        InterceptProposal TryFindIntercept(List<Wagon> wagons, Shipment newShipment);
    }

    public class InterceptEngine : IInterceptEngine
    {
        private const double MaxInterceptRadiusKm = 200.0;
        private const decimal EmptyRunCostPerKm = 20m;
        private const decimal SortingStationBonus = 500m;
        private const decimal MinSavingsThresholdUah = 1000m;

        private readonly IGeoCalculator _geoCalculator;

        public InterceptEngine(IGeoCalculator geoCalculator)
        {
            _geoCalculator = geoCalculator;
        }

        public InterceptProposal TryFindIntercept(List<Wagon> wagons, Shipment newShipment)
        {
            var compatibleWagons = wagons
                .Where(w => IsCompatible(w.Type, newShipment.Cargo))
                .ToList();

            Wagon? bestWagon = null;
            decimal maxSavings = 0;
            double bestDistanceToNewLoad = 0;

            foreach (var wagon in compatibleWagons)
            {
                double distanceToNewLoad = _geoCalculator.GetDistance(
                    wagon.CurrentStationId,
                    newShipment.FromStationId
                );

                if (distanceToNewLoad > MaxInterceptRadiusKm)
                {
                    continue;
                }

                if (wagon.TargetStationId.HasValue)
                {
                    decimal oldDistanceToTarget = (decimal)
                        _geoCalculator.GetDistance(
                            wagon.CurrentStationId,
                            wagon.TargetStationId.Value
                        );
                    decimal newLoadDistance = (decimal)
                        _geoCalculator.GetDistance(
                            wagon.CurrentStationId,
                            newShipment.FromStationId
                        );
                    decimal savings =
                        oldDistanceToTarget * EmptyRunCostPerKm
                        - newLoadDistance * EmptyRunCostPerKm;

                    if (wagon.IsOnSortingStation)
                    {
                        savings += SortingStationBonus;
                    }

                    if (savings > maxSavings)
                    {
                        bestWagon = wagon;
                        maxSavings = savings;
                        bestDistanceToNewLoad = distanceToNewLoad;
                    }
                }
            }

            if (maxSavings < MinSavingsThresholdUah || bestWagon == null)
            {
                return new InterceptProposal { IsFound = false };
            }

            return new InterceptProposal
            {
                IsFound = true,
                SuggestedWagon = bestWagon,
                SavedMoneyUah = maxSavings,
                SavedDistanceKm =
                    (
                        bestWagon.TargetStationId.HasValue
                            ? _geoCalculator.GetDistance(
                                bestWagon.CurrentStationId,
                                bestWagon.TargetStationId.Value
                            )
                            : 0
                    ) - bestDistanceToNewLoad,
                DistanceToNewLoad = bestDistanceToNewLoad,
            };
        }

        private static bool IsCompatible(WagonType wagonType, CargoType cargoType)
        {
            return (wagonType, cargoType) switch
            {
                (WagonType.OpenTop, CargoType.Ore) => true,
                (WagonType.OpenTop, CargoType.Rubble) => true,
                (WagonType.GrainHopper, CargoType.Grain) => true,
                (WagonType.CementWagon, CargoType.Cement) => true,
                _ => false,
            };
        }
    }
}
