using System;

namespace hakaton_yz_api.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public double FromLat { get; set; }
        public double FromLon { get; set; }

        public double ToLat { get; set; }
        public double ToLon { get; set; }
        public string FromCity { get; set; } = string.Empty;
        public string ToCity { get; set; } = string.Empty;

        public DateTime Deadline { get; set; }
        public bool IsAssigned { get; set; }
        public string Status { get; set; } = "Pending";
    }
}