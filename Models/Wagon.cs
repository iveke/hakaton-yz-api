using System;

namespace hakaton_yz_api.Models
{
    public class Wagon
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}