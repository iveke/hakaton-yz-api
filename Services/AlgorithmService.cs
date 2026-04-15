using System;
using System.Collections.Generic;
using System.Linq;
using hakaton_yz_api.Models;
using System.Threading.Tasks;

namespace hakaton_yz_api.Services
{
    public class AlgorithmService
    {
        private readonly ICostMatrixService _costMatrixService;
        private readonly IInterceptEngine _interceptEngine;
        private readonly HotOfferService _hotOfferService;

        public AlgorithmService(
            ICostMatrixService costMatrixService,
            IInterceptEngine interceptEngine,
            HotOfferService hotOfferService)
        {
            _costMatrixService = costMatrixService;
            _interceptEngine = interceptEngine;
            _hotOfferService = hotOfferService;
        }

        /// <summary>
        /// Головний pipeline для підбору вагонів під заявки з урахуванням усіх бізнес-правил.
        /// </summary>
        public async Task<List<AssignmentProposal>> MatchWagonsToShipments(
            List<Wagon> wagons,
            List<Shipment> shipments)
        {
            // 1. Відфільтрувати доступні вагони та непідтверджені заявки
            var availableWagons = wagons.Where(w => w.IsAvailable).ToList();
            var pendingShipments = shipments.Where(s => !s.IsAssigned && s.Status == "Pending").ToList();

            // 2. Розрахувати матрицю вартостей
            var costEdges = _costMatrixService.CostMatrix(availableWagons, pendingShipments);

            // 3. Для кожної заявки знайти найкращий вагон (мінімальна TotalCost)
            var proposals = new List<AssignmentProposal>();
            foreach (var shipment in pendingShipments)
            {
                var bestEdge = costEdges
                    .Where(e => e.ShipmentId == shipment.Id)
                    .OrderBy(e => e.TotalCost)
                    .FirstOrDefault();
                if (bestEdge == null) continue;

                var wagon = availableWagons.FirstOrDefault(w => w.Id == bestEdge.WagonId);
                if (wagon == null) continue;

                // 4. Перевірити можливість інтерцепту
                var intercept = _interceptEngine.TryFindIntercept(availableWagons, shipment);

                // 5. Додати гарячі пропозиції
                var hotOffers = _hotOfferService.GenerateOffers(availableWagons);
                var hotOffer = hotOffers.FirstOrDefault(o => o.WagonId == wagon.Id);

                proposals.Add(new AssignmentProposal
                {
                    Wagon = wagon,
                    Shipment = shipment,
                    TotalCost = bestEdge.TotalCost,
                    DistanceKm = bestEdge.DistanceKm,
                    Intercept = intercept,
                    HotOffer = hotOffer
                });
            }

            // 6. Видаємо список пропозицій для підтвердження (можна сортувати за TotalCost)
            return proposals.OrderBy(p => p.TotalCost).ToList();
        }
    }

    /// <summary>
    /// DTO для пропозиції призначення вагона на заявку
    /// </summary>
    public class AssignmentProposal
    {
        public Wagon? Wagon { get; set; }
        public Shipment? Shipment { get; set; }
        public decimal TotalCost { get; set; }
        public double DistanceKm { get; set; }
        public InterceptProposal? Intercept { get; set; }
        public HotOffer? HotOffer { get; set; }
    }
}
