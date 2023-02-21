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
                //foreach(var offer in _context.OfferedRides)
                //{
                //    if (offer.From == bookedRide.From || offer.Stop1 == bookedRide.From || offer.Stop2 == bookedRide.From || offer.Stop3 == bookedRide.From || offer.Stop4 == bookedRide.From || offer.Stop5 == bookedRide.From)
                //    {
                //        if (offer.Stop1 == bookedRide.To || offer.Stop2 == bookedRide.To || offer.Stop3 == bookedRide.To || offer.Stop4 == bookedRide.To || offer.Stop5 == bookedRide.To)
                //        {
                //            bookedRide.OfferId = offer.OfferedRideId;
                //        }
                //    }
                //}
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
