using System;
using System.Collections.Generic;
using System.Linq;
using hakaton_yz_api.Models;

namespace hakaton_yz_api.Services
{
    /// <summary>
    /// Interface for the intercept engine.
    /// </summary>
    public interface IInterceptEngine
    {
        /// <summary>
        /// Attempts to find the best wagon to intercept for a new shipment.
        /// </summary>
        /// <param name="wagons">The list of wagons to consider.</param>
        /// <param name="newShipment">The new shipment to be handled.</param>
        /// <returns>An intercept proposal with the best wagon and savings, if successful.</returns>
        InterceptProposal TryFindIntercept(List<Wagon> wagons, Shipment newShipment);
    }

    /// <summary>
    /// Implementation of the intercept engine.
    /// </summary>
    public class InterceptEngine : IInterceptEngine
    {
        private const double MaxInterceptRadiusKm = 200.0;
        private readonly IDistanceCalculator _distanceCalculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="InterceptEngine"/> class.
        /// </summary>
        /// <param name="distanceCalculator">The distance calculator to use.</param>
        public InterceptEngine(IDistanceCalculator distanceCalculator)
        {
            _distanceCalculator = distanceCalculator;
        }

        /// <inheritdoc />
        public InterceptProposal TryFindIntercept(List<Wagon> wagons, Shipment newShipment)
        {
            var movingWagons = wagons.Where(w => w.IsMoving && w.TargetCity != null).ToList();

            Wagon? bestWagon = null;
            double maxSavings = 0;
            double bestDistanceToNewLoad = 0;

            foreach (var wagon in movingWagons)
            {
                double distanceToNewLoad = _distanceCalculator.GetDistance(
                    wagon.City,
                    newShipment.FromCity
                );

                if (distanceToNewLoad > MaxInterceptRadiusKm)
                {
                    continue;
                }

                double distanceToOldTarget = _distanceCalculator.GetDistance(
                    wagon.City,
                    wagon.TargetCity!
                );
                double savings = distanceToOldTarget - distanceToNewLoad;

                if (savings > maxSavings)
                {
                    bestWagon = wagon;
                    maxSavings = savings;
                    bestDistanceToNewLoad = distanceToNewLoad;
                }
            }

            if (bestWagon == null)
            {
                return new InterceptProposal { IsSuccessful = false };
            }

            return new InterceptProposal
            {
                IsSuccessful = true,
                SuggestedWagon = bestWagon,
                SavedDistanceKm = maxSavings,
                DistanceToNewLoad = bestDistanceToNewLoad,
            };
        }
    }
}
