using MovieBooking.Contracts;
namespace MovieBooking.Services.MovieManagementService
{
    public interface IMovieManagementService
    {
        public IEnumerable<Movie> GetAllMovies();

        public void AddNewMovie(Movie movie);
    }
}
