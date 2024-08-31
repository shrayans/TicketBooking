using MovieBooking.Contracts;
namespace MovieBooking.Services.BookingService
{
    public interface IBookingService
    {
        public IEnumerable<string> GetListOfCity();

        public IEnumerable<Movie> GetAvailableMoviesInCity(string cityName);

        public IEnumerable<Show> GetAllShowsOfMovie(string cityName, int movieId);

        public Screen GetAvailableSeatsInShow(string cityName, int showId);

        public bool BookSeatInShow(string cityName, int showId, int seatId);
    }
}
