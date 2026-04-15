using System;

namespace hakaton_yz_api.Models
{
    public class Wagon
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; } = string.Empty;
        public string? DestinationCity { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string? TargetCity { get; set; }
        public bool IsMoving { get; set; }
        public WagonType Type { get; set; }
        public int CurrentStationId { get; set; }
        public int? TargetStationId { get; set; }
        public bool IsOnSortingStation { get; set; }
    }
}
