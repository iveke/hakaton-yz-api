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
        Shipment? shipment = await _context.Shipments.FindAsync(shipmentId);
        if (shipment == null)
        {
            return NotFound("Shipment not found");
        }

        List<Wagon> availableWagons = await _context.Wagons.Where(w => w.IsAvailable).ToListAsync();
        
        IEnumerable<object>? suggestions = _algorithmService.SuggestBestWagons(availableWagons, shipment);
        
        if (suggestions == null || !suggestions.Any())
        {
            return NotFound("No available wagons found");
        }

        return Ok(suggestions);
    }
}
