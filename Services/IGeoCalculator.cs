namespace hakaton_yz_api.Services
{
    public interface IGeoCalculator
    {
        double GetDistance(int stationIdA, int stationIdB);
    }
}
