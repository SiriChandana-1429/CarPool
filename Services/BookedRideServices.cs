using DatabaseContext;
using Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookedRideServices:IBookedRide
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
        public BookedRide AddBookRide(BookedRide bookedRide)
        {
            bool Flag = true;
            char currentSeats;
            if (ValidateRide(bookedRide.OfferId))
            {
                int FromStop= (int)Enum.Parse(typeof(Stop),bookedRide.From);
                int ToStop = (int)Enum.Parse(typeof(Stop), bookedRide.To);
                foreach(var offer in _context.OfferedRides)
                {
                    if (offer.AccomodatedString.Length < ToStop)
                    {
                        break;
                    }
                    foreach(char seat in offer.AccomodatedString.Substring(FromStop, ToStop))
                    {
                        if ((int)seat < bookedRide.seats)
                        {
                            Flag = false;
                            break;
                        }
                        currentSeats = seat;
                    }
                    if (Flag)
                    {
                        string changedSeats = String.Concat(Enumerable.Repeat(offer.AccomodatedString[FromStop].ToString(), ToStop-FromStop));
                        string currentAccomodatedString = offer.AccomodatedString.Substring(0, FromStop)+changedSeats+offer.AccomodatedString.Substring(ToStop,offer.AccomodatedString.Length-1);
                        offer.AccomodatedString = currentAccomodatedString;
                        _context.BookedRides.Add(bookedRide);
                        _context.SaveChangesAsync();
                        return bookedRide;
                    }
                }
                return null;
                
            }
            else
            {
                return null;
            }
        }
        public List<BookedRide> GetAllRides()
        {
            return _context.BookedRides.ToList();
        }
        public BookedRide GetRideById(int id)
        {
            if (_context.BookedRides == null)
            {
                return null;
            }
            var check = _context.BookedRides.Find(id);
            if (check == null)
            {
                return null;
            }
            else
            {
                return check;
            }
        }
        public bool IsInPath(string path,string requiredPath)
        {
            
            foreach (OfferedRide offer in _context.OfferedRides)
            {
                string[] IntermediateStopsArray=offer.IntermediateStops.Split( ",");
                string completePath = offer.From;
                for(int i=0;i<IntermediateStopsArray.Length;i++) 
                {
                    completePath += IntermediateStopsArray[i].ToString();
                }
                completePath += offer.To;
                if (completePath.Contains(requiredPath))
                {
                    return true;
                }
               
            }
            return false;
        }

    }
}
