using System;

namespace hakaton_yz_api.Models
{
    public class InterceptProposal
    {
        public bool IsFound { get; set; }

        public Wagon? SuggestedWagon { get; set; }

        public decimal SavedMoneyUah { get; set; }

        public double SavedDistanceKm { get; set; }

        public double DistanceToNewLoad { get; set; }
    }
}
