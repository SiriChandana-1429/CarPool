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
                    foreach(var offer in _context.OfferedRides)
                    {
                    List<string> TotalStops = new List<string>
                {
                    offer.From,
                };
                    foreach (string stop in offer.IntermediateStops.Split(","))
                    {
                        TotalStops.Add(stop);
                    }
                TotalStops.Add(offer.To);
                int FromStop = TotalStops.IndexOf(bookedRide.From);
                int ToStop = TotalStops.IndexOf(bookedRide.To);
                if (offer.AccomodatedString.Length <= ToStop)
                    {
                        break;
                    }
                    foreach(char seat in offer.AccomodatedString.Substring(FromStop, ToStop - FromStop - 1))
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
                        int value = (offer.AccomodatedString[FromStop]-'0')-bookedRide.seats;
                        string changedSeats = String.Concat(Enumerable.Repeat(value.ToString(), ToStop-FromStop));
                    
                        string currentAccomodatedString = offer.AccomodatedString.Substring(0, FromStop)+changedSeats+offer.AccomodatedString[ToStop..(offer.AccomodatedString.Length)];
                        offer.AccomodatedString = currentAccomodatedString;
                        bookedRide.OfferId = offer.OfferedRideId;
                        
                        _context.BookedRides.Add(bookedRide);
                        _context.SaveChangesAsync();
                        return bookedRide;
                    }
                }
                return null;
                
           
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
        public bool IsInPath(string path,string requiredPath,BookedRide bookedRide)
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
                (int,int) stops=IsValidPath(completePath, path);
                if (stops.Item1 == -1 || stops.Item2 == -1)
                {
                    return false;
                }
                if(stops.Item1>stops.Item2)
                {
                    return false;
                }
                else
                {
                    foreach(char c in offer.AccomodatedString.Substring(stops.Item1-1, stops.Item2-stops.Item1-1))
                    {
                        if((int)c==0)
                        {
                            return false;
                        }
                        
                    }
                    string temp = "";
                    for(int i=stops.Item1;i<stops.Item2; i++)
                    {
                        int curr = (int)offer.AccomodatedString[i]-bookedRide.seats;
                        temp += curr.ToString();

                    }
                    offer.AccomodatedString.Replace(offer.AccomodatedString.Substring(stops.Item1 - 1, stops.Item2-stops.Item1-1), temp);
                    return true;
                    
                }
               
            }
            return false;
        }
        
        public (int,int) IsValidPath(string string1,string string2)
        {
            char FirstStop = string2[0];
            int flag1 = -1;
            int flag2=-1;
            char SecondStop = string2[1];
            for(int i=0;i<string1.Length;i++)
            {
                if (string1[i].Equals(FirstStop))
                {
                    flag1 = i;
                }
                if (string1[i].Equals(SecondStop))
                {
                    flag2 = i;
                }
            }
            
            return (flag1, flag2);
        }
    }
}
