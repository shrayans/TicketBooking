using MovieBooking.Contracts;

namespace MovieBooking.Services.MovieManagementService
{
    public class MovieManagementService : IMovieManagementService
    {
        private List<Movie> movies = new List<Movie>
        {
            new Movie { MovieId = 1, Title = "Inception", Genre = "Sci-Fi", ReleaseDate = new DateTime(2010, 7, 16) },
            new Movie { MovieId = 2, Title = "The Matrix", Genre = "Action", ReleaseDate = new DateTime(1999, 3, 31) }
        };

        public IEnumerable<Movie> GetAllMovies()
        {
            return movies;
        }

        public void AddNewMovie(Movie movie)
        {
            movies.Add(movie);
        }
    }
}
