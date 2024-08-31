namespace MovieBooking.Contracts
{
    public class Theatre
    {
        public int TheatreId { get; set; }
        public string TheatreName { get; set; }
        public string TheatreCity { get; set; }
        public List<Screen> Screens { get; set; }
        public List<Show> Shows { get; set; }
    }
}
