using System;
namespace hakaton_yz_api.Models
{
    public class CostEdge
    {
        public Guid WagonId { get; set; }
        public Guid ShipmentId { get; set; }
        public double DistanceKm { get; set; }
        public decimal TotalCost { get; set; }
    }
}