using MovieBooking.Contracts;
using MovieBooking.Services.MovieManagementService;
using MovieBooking.Services.TheatreManagementService;

namespace MovieBooking.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private IMovieManagementService movieManagementService;
        private ITheatreManagementService theatreManagementService;

        public BookingService(
            IMovieManagementService movieManagementService,
            ITheatreManagementService theatreManagementService) 
        {
            this.movieManagementService = movieManagementService;
            this.theatreManagementService = theatreManagementService;
        }

        public bool BookSeatInShow(string cityName, int showId, int seatId)
        {
            Show selectedShow = null;
            List<Theatre> theatres = theatreManagementService.GetAllTheatres().ToList();

            foreach (var theatre in theatres)
            {
                if (theatre.TheatreCity == cityName)
                {
                    List<Show> shows = theatre.Shows;
                    foreach (var show in shows)
                    {
                        if (show.ShowId == showId)
                        {
                            selectedShow = show;
                            break;
                        }
                    }
                }
            }
            if (selectedShow.bookedSeats.Contains(seatId))
            {
                return false;
            }
            selectedShow.bookedSeats.Add(seatId);
            return true;
        }

        public IEnumerable<Show> GetAllShowsOfMovie(string cityName, int movieId)
        {
            List<Show> rslt = new List<Show>();
            List<Theatre> theatres = theatreManagementService.GetAllTheatres().ToList();

            foreach (var theatre in theatres)
            {
                if(theatre.TheatreCity == cityName)
                {
                    List<Show> shows = theatre.Shows;
                    foreach (var show in shows)
                    {
                        if(show.movieId == movieId)
                        {
                            rslt.Add(show);
                        }
                    }
                }
            }
            return rslt;
        }

        public IEnumerable<Movie> GetAvailableMoviesInCity(string cityName)
        {
            List<Movie> movies = new List<Movie>();

            HashSet<int> movieid = new HashSet<int>();

            List<Theatre> theatres = theatreManagementService.GetAllTheatres().ToList();
            

            foreach (var theatre in theatres)
            {
                if(theatre.TheatreCity==cityName)
                {
                    foreach(var show in theatre.Shows)
                    {
                        movieid.Add(show.movieId);
                    }
                }
            }

            List<Movie> mvsList = movieManagementService.GetAllMovies().ToList();

            foreach(var movie in mvsList)
            {
                if(movieid.Contains(movie.MovieId))
                {
                    movies.Add(movie);
                }
            }

            return movies;
        }

        public Screen GetAvailableSeatsInShow(string cityName, int showId)
        {
            Show selectedShow = null;
            List<Theatre> theatres = theatreManagementService.GetAllTheatres().ToList();

            foreach (var theatre in theatres)
            {
                if (theatre.TheatreCity == cityName)
                {
                    List<Show> shows = theatre.Shows;
                    foreach (var show in shows)
                    {
                        if (show.ShowId == showId)
                        {
                            selectedShow = show;
                            break;
                        }
                    }
                }
            }

            Screen screen = null;

            foreach (var theatre in theatres)
            {
                if (theatre.TheatreCity == cityName)
                {
                    List<Screen> screens = theatre.Screens;
                    foreach (var scrn in screens)
                    {
                        if (scrn.ScreenId == selectedShow.screenId)
                        {
                            screen = scrn;
                            break;
                        }
                    }
                }
            }
            return screen;
        }

        public IEnumerable<string> GetListOfCity()
        {
            List<Theatre> theatres = theatreManagementService.GetAllTheatres().ToList();
            List<string> cities = new List<string>();
            foreach (var theatre in theatres)
            {
                cities.Add(theatre.TheatreCity);
            }
            return cities;
        }
    }
}
