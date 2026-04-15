using System;
using System.Collections.Generic;
using hakaton_yz_api.Models;

public interface ICostMatrixService
{
	List<CostEdge> CostMatrix(List<Wagon> wagons, List<Shipment> pendingShipments);
}
