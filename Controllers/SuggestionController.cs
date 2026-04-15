using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;
using hakaton_yz_api.Services;

using hakaton_yz_api.Models;
using hakaton_yz_api.Data;

[ApiController]
[Route("suggestion")]
public class SuggestionController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly AlgorithmService _algorithmService;

    public SuggestionController(AppDbContext context, AlgorithmService algorithmService)
    {
        _context = context;
        _algorithmService = algorithmService;
    }

    [HttpGet("{shipmentId}")]
    public async Task<IActionResult> GetSuggestion(Guid shipmentId)
    {
        var shipment = await _context.Shipments.FindAsync(shipmentId);
        if (shipment == null)
        {
            return NotFound("Shipment not found");
        }

        var allWagons = await _context.Wagons.ToListAsync();
        var allShipments = await _context.Shipments.ToListAsync();

        var proposals = await _algorithmService.MatchWagonsToShipments(allWagons, allShipments);
        var filtered = proposals.Where(p => p.Shipment != null && p.Shipment.Id == shipmentId).ToList();
        if (!filtered.Any())
        {
            return NotFound("No suitable wagons found");
        }
        return Ok(filtered);
    }
}
