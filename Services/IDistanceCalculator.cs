namespace hakaton_yz_api.Services
{
    /// <summary>
    /// Interface for calculating distances between cities.
    /// </summary>
    public interface IDistanceCalculator
    {
        /// <summary>
        /// Calculates the distance between two cities.
        /// </summary>
        /// <param name="cityA">The name of the first city.</param>
        /// <param name="cityB">The name of the second city.</param>
        /// <returns>The distance between the two cities in kilometers.</returns>
        double GetDistance(string cityA, string cityB);
    }
}
