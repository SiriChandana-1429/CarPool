using DatabaseContext;
using Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class OfferedRideServices:ControllerBase,IOfferedRide
    {
        private readonly MyDbContext _context;

        public OfferRideServices(MyDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<OfferedRide>> AddOfferRide(OfferedRide offeredRide)
        {
            _context.OfferedRides.Add(offeredRide);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferedRide", new { id = offeredRide.Id }, offeredRide);
        }
        public async Task<ActionResult<List<OfferedRide>>> GetOfferRide()
        {
            return await _context.OfferedRides.ToListAsync();
        }
        public async Task<ActionResult<OfferedRide>> GetOfferRideById(int id)
        {
            if (_context.OfferedRides == null)
            {
                return NotFound();
            }
            var check = await _context.OfferedRides.FindAsync(id);
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
