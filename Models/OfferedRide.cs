namespace WebApplication1.Models
{
    public class OfferedRide
    {
        public int Id { get; set; }
        public string OfferedRideId { get; set; }
        public string OfferedUserId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string? AccomodatedString { get; set; }
        public int NoOfSeats { get; set; }
        public string IntermediateStops { get; set; }
        
    }
}
