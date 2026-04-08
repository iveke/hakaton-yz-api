using System;

namespace hakaton_yz_api.Models
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public Guid WagonId { get; set; }
        public Guid ShipmentId { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}
