using System;
using System.Collections.Generic;
using hakaton_yz_api.Models;

public interface ICostMatrixService
{
	public List<CostEdge> CostMatrix(List<Wagon> wagons, List<Shipment> pendingShipments);
    private double CalculateDistance(double lat1, double lon1, double lat2, double lon2);
}
