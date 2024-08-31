using MovieBooking.Contracts;
using MovieBooking.Services.MovieManagementService;

namespace MovieBooking.Services.TheatreManagementService
{
    public class TheatreManagementService : ITheatreManagementService
    {
        private List<Theatre> theatreList;
        IMovieManagementService movieManagementService;

        public TheatreManagementService(IMovieManagementService movieManagementService)
        {
            theatreList = new List<Theatre>
            {
                new Theatre
                {
                    TheatreId = 1,
                    TheatreCity = "hyd",
                    TheatreName = "pvr",
                    Screens = new List<Screen>(),
                    Shows = new List<Show>()
                }
            };
            this.movieManagementService = movieManagementService;
        }

        public void CreateNewTheatre(Theatre theatre)
        {
            theatreList.Add(theatre);
        }

        public void AddScreenInTheatre(Screen screen)
        {
            var theatre = theatreList.FirstOrDefault(t => t.TheatreId == screen.TheatreId);
            if (theatre != null && screen != null)
            {
                theatre.Screens.Add(screen);
            }
            else
                throw new Exception();

        }

        public void CreateShow(int theatreId, Show show)
        {
            var theatre = theatreList.FirstOrDefault(t => t.TheatreId == theatreId);

            List<Movie> movies = movieManagementService.GetAllMovies().ToList();

            if (theatre != null && show != null)
            {
                if (theatre.Screens.Any(s => s.ScreenId == show.screenId) &&
                        movies.Any(m => m.MovieId == show.movieId))
                {
                    theatre.Shows.Add(show);
                }
                else
                    throw new Exception();
            }
            else
                throw new Exception();
        }

        public IEnumerable<Theatre> GetAllTheatres()
        {
            return theatreList;
        }
    }
}
