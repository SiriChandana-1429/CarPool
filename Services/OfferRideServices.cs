using DatabaseContext;
using Interfaces;
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
            int FromStop = (int)Enum.Parse(typeof(Stop), offeredRide.From);
            int ToStop = (int)Enum.Parse(typeof(Stop), offeredRide.To);
            offeredRide.AccomodatedString = String.Concat(Enumerable.Repeat(offeredRide.NoOfSeats.ToString(), ToStop-FromStop));
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
