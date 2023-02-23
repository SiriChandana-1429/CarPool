using DatabaseContext;
using Interfaces;
using System;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class OfferedRideServices:IOfferedRide
    {
        private readonly MyDbContext _context;
        
        public OfferedRideServices(MyDbContext context)
        {
            _context = context;
        }
        public void AddOfferRide(OfferedRide offeredRide)
        {
            List<string> TotalStops = new List<string>
            {
                offeredRide.From,
            };
            foreach (string stop in offeredRide.IntermediateStops.Split(","))
            {
                TotalStops.Add(stop);
            }
            TotalStops.Add(offeredRide.To);
            int FromStop = TotalStops.IndexOf(offeredRide.From);
            int ToStop = TotalStops.IndexOf(offeredRide.To);
            offeredRide.AccomodatedString = String.Concat(Enumerable.Repeat(offeredRide.NoOfSeats.ToString(), ToStop-FromStop+1));
            _context.OfferedRides.Add(offeredRide);
            _context.SaveChangesAsync();
            

           // return CreatedAtAction("GetOfferedRide", new { id = offeredRide.Id }, offeredRide);
        }
        public List<OfferedRide> GetOfferRide()
        {
            return _context.OfferedRides.ToList();
        }
        public OfferedRide GetOfferRideById(int id)
        {
            if (_context.OfferedRides == null)
            {
                return null;
            }
            var check = _context.OfferedRides.Find(id);
            if (check == null)
            {
                return null;
            }
            else
            {
                return check;
            }
        }
    }
}
