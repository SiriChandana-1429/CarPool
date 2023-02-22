using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace Interfaces
{
    public interface IBookedRide
    {
        public bool ValidateRide(string offerId);
        public BookedRide AddBookRide(BookedRide bookedRide);
        public List<BookedRide> GetAllRides();
        public BookedRide GetRideById(int id);
        
    }
}
