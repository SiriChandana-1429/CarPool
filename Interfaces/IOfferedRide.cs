using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace Interfaces
{
    public interface IOfferedRide
    {
        public Task<ActionResult<OfferedRide>> AddOfferRide(OfferedRide offeredRide);
        public Task<ActionResult<List<OfferedRide>>> GetOfferRide();
        public Task<ActionResult<OfferedRide>> GetOfferRideById(int id);
        


        }
}
