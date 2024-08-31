namespace MovieBooking.Contracts
{
    public class Booking
    {
        public int ShowId { get; set; }
        public List<Seat> BookedSeats { get; set; }
        public Payment paymentDetails { get; set; }
    }
}
