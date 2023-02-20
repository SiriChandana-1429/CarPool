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
        public string? Stop1 { get; set; }
        public string? Stop2 { get; set; }
        public string? Stop3 { get; set; }
        public string? Stop4 { get; set; }
        public string? Stop5 { get; set; }

    }
}
