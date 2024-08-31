using Microsoft.AspNetCore.Mvc;
using MovieBooking.Contracts;

namespace MovieBooking.Services.MovieManagementService
{
    [ApiController]
    [Route("admin/movies")]
    public class MovieManagementController: ControllerBase
    {
        private IMovieManagementService movieManagementService;

        public MovieManagementController(IMovieManagementService movieManagementService)
        {
            this.movieManagementService = movieManagementService;
        }

        [HttpGet("listAllMovies")]
        public ActionResult Get()
        {
            return Ok(movieManagementService.GetAllMovies());
        }

        [HttpPost("addNewMovie")]
        public ActionResult AddNewMovie(Movie movie)
        {
            movieManagementService.AddNewMovie(movie);
            return Ok();
        }
    }
}
