using DatabaseContext;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookedRideServices:ControllerBase,IBookedRide
    {
        private readonly MyDbContext _context;

        public BookedRideServices(MyDbContext context)
        {
            _context = context;
        }
        public bool ValidateRide(string offerId)
        {
            if (offerId == null) return false;
            var check = _context.OfferedRides.Find(offerId);
            if (check == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public async Task<ActionResult<BookedRide>> AddBookRide(BookedRide bookedRide)
        {
            if (ValidateRide(bookedRide.OfferId))
            {
                _context.BookedRides.Add(bookedRide);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBookedRide", new { id = bookedRide.Id }, bookedRide);
            }
            else
            {
                return BadRequest();
            }
        }
        public async Task<ActionResult<List<BookedRide>>> GetAllRides()
        {
            return await _context.BookedRides.ToListAsync();
        }
        public async Task<ActionResult<BookedRide>> GetRideById(int id)
        {
            if (_context.BookedRides == null)
            {
                return NotFound();
            }
            var check = await _context.BookedRides.FindAsync(id);
            if (check == null)
            {
                return NotFound();
            }
            else
            {
                return check;
            }
        }

    }
}
