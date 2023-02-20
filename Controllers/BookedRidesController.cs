using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseContext;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookedRidesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public BookedRidesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/BookedRides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookedRide>>> GetBookedRides()
        {
            return await _context.BookedRides.ToListAsync();
        }

        // GET: api/BookedRides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookedRide>> GetBookedRide(int id)
        {
            var bookedRide = await _context.BookedRides.FindAsync(id);

            if (bookedRide == null)
            {
                return NotFound();
            }

            return bookedRide;
        }


        // POST: api/BookedRides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        




    }
}
