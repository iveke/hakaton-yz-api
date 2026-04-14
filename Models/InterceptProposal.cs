using System;

namespace hakaton_yz_api.Models
{
    /// <summary>
    /// Represents a proposal for intercepting a wagon to save distance.
    /// </summary>
    public class InterceptProposal
    {
        /// <summary>
        /// Indicates whether the intercept was successful.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// The suggested wagon for the intercept, if successful.
        /// </summary>
        public Wagon? SuggestedWagon { get; set; }

        /// <summary>
        /// The distance saved by the intercept, in kilometers.
        /// </summary>
        public double SavedDistanceKm { get; set; }

        /// <summary>
        /// The distance to the new load, in kilometers.
        /// </summary>
        public double DistanceToNewLoad { get; set; }
    }
}
