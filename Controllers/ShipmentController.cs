using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

using hakaton_yz_api.Models;
using hakaton_yz_api.Data;

[ApiController]
[Route("shipments")]
public class ShipmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShipmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
    {
        return await _context.Shipments.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Shipment>> CreateShipment(Shipment shipment)
    {
        _context.Shipments.Add(shipment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetShipments), new { id = shipment.Id }, shipment);
    }

    [HttpPost("assign")]
    public async Task<IActionResult> CreateAssignment([FromBody] AssignmentRequest request)
    {
        Wagon? wagon = await _context.Wagons.FindAsync(request.WagonId);
        Shipment? shipment = await _context.Shipments.FindAsync(request.ShipmentId);

        if (wagon == null || shipment == null)
        {
            return NotFound("Wagon or Shipment not found");
        }

        if (!wagon.IsAvailable)
        {
            return BadRequest("Wagon is not available");
        }

        if (shipment.IsAssigned || shipment.Status == "Assigned")
        {
            return BadRequest("Shipment is already assigned");
        }

        // Logic: mark wagon as unavailable, mark shipment as assigned
        wagon.IsAvailable = false;
        shipment.IsAssigned = true;
        shipment.Status = "Assigned";

        Assignment assignment = new Assignment
        {
            Id = Guid.NewGuid(),
            WagonId = wagon.Id,
            ShipmentId = shipment.Id,
            AssignedAt = DateTime.UtcNow
        };

        _context.Assignments.Add(assignment);
        await _context.SaveChangesAsync();

        return Ok(assignment);
    }
}

public class AssignmentRequest
{
    public Guid WagonId { get; set; }
    public Guid ShipmentId { get; set; }
}
