using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferedRidesController : ControllerBase
    {
        public IOfferedRide offeredRideServices;

        public OfferedRidesController(IOfferedRide offeredRideServices)
        {
            this.offeredRideServices = offeredRideServices;
        }

        // GET: api/OfferedRides
        [HttpGet]
        public async Task<ActionResult<List<OfferedRide>>> GetOfferedRides()
        {
            if (offeredRideServices.GetOfferRide() == null)
            {
                return NotFound();
            }
            return  Ok(offeredRideServices.GetOfferRide());
        }

        // GET: api/OfferedRides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferedRide>> GetOfferedRide(int id)
        {
            if(offeredRideServices.GetOfferRideById(id) == null)
            {
                return NotFound();
            }

            return Ok(offeredRideServices.GetOfferRideById(id));
        }


        // POST: api/OfferedRides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostOfferedRide(OfferedRide offeredRide)
        {
            offeredRideServices.AddOfferRide(offeredRide);
        }

        
    }
}
