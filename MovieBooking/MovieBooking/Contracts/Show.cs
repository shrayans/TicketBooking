namespace MovieBooking.Contracts
{
    public class Show
    {
        public int ShowId { get; set; }
        public int movieId { get; set; }
        public int screenId { get; set; }
        public DateTime startTime { get; set; }
        public List<int> bookedSeats { get; set; }
        
    }
}
