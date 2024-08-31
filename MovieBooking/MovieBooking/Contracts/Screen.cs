namespace MovieBooking.Contracts
{
    public class Screen
    {
        public int TheatreId { get; set; }
        public int ScreenId { get; set; }
        public List<Seat> SeatList { get; set; }
    }
}
