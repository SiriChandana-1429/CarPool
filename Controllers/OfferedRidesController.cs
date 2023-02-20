using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferedRidesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public OfferedRidesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/OfferedRides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferedRide>>> GetOfferedRides()
        {
            return await _context.OfferedRides.ToListAsync();
        }

        // GET: api/OfferedRides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferedRide>> GetOfferedRide(int id)
        {
            var offeredRide = await _context.OfferedRides.FindAsync(id);

            if (offeredRide == null)
            {
                return NotFound();
            }

            return offeredRide;
        }


        // POST: api/OfferedRides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfferedRide>> PostOfferedRide(OfferedRide offeredRide)
        {
            _context.OfferedRides.Add(offeredRide);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferedRide", new { id = offeredRide.Id }, offeredRide);
        }

        
    }
}
