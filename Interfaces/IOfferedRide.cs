using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace Interfaces
{
    public interface IOfferedRide
    {
        public void AddOfferRide(OfferedRide offeredRide);
        public List<OfferedRide> GetOfferRide();
        public OfferedRide GetOfferRideById(int id);
        


        }
}
