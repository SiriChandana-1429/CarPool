using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace Interfaces
{
    public interface IBookedRide
    {
        public bool ValidateRide(string offerId);
        public Task<ActionResult<BookedRide>> AddBookRide(BookedRide bookedRide);
        public Task<ActionResult<List<BookedRide>>> GetAllRides();
        public Task<ActionResult<BookedRide>> GetRideById(int id);
        
    }
}
