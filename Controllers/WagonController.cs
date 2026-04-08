using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

using hakaton_yz_api.Models;
using hakaton_yz_api.Data;

[ApiController]
[Route("wagons")]
public class WagonController : ControllerBase
{
    private readonly AppDbContext _context;

    public WagonController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wagon>>> GetWagons([FromQuery] bool? isAvailable)
    {
        System.Linq.IQueryable<Wagon> query = _context.Wagons.AsQueryable();

        if (isAvailable.HasValue)
        {
            query = query.Where(w => w.IsAvailable == isAvailable.Value);
        }

        return await query.ToListAsync();
    }
}
