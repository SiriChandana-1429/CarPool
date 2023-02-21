using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookedRidesController : ControllerBase
    {
        
        public IBookedRide bookedRideServices;

        public BookedRidesController(IBookedRide bookedRideServices)
        {     
            this.bookedRideServices=bookedRideServices;
        }

        // GET: api/BookedRides
        [HttpGet]
        public async Task<ActionResult<List<BookedRide>>> GetBookedRides()
        {
            return await bookedRideServices.GetAllRides();
        }

        // GET: api/BookedRides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookedRide>> GetBookedRide(int id)
        {
            return await bookedRideServices.GetRideById(id);
        }


        // POST: api/BookedRides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        




    }
}
