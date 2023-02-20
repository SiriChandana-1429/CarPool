namespace WebApplication1.Models
{
    public class BookedRide
    {
        public int Id { get; set; }
        public string? BookedUserId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string OfferId { get; set; }
        public int seats { get; set; }
    }
}
