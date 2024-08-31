using Microsoft.AspNetCore.Mvc;
using MovieBooking.Contracts;

namespace MovieBooking.Services.BookingService
{
    [ApiController]
    [Route("booking")]
    public class BookingServiceController: ControllerBase
    {
        private IBookingService bookingService;

        public BookingServiceController(IBookingService movieManagementService)
        {
            this.bookingService = movieManagementService;
        }


        [HttpGet("listOfCities")]
        public ActionResult GetListOfCity()
        {
            return Ok(bookingService.GetListOfCity());
        }

        [HttpGet("{cityName}/Movies")]
        public ActionResult GetAvailableMoviesInCity(string cityName)
        {
            return Ok(bookingService.GetAvailableMoviesInCity(cityName));
        }

        [HttpGet("{cityName}/Movies/{movieId}")]
        public ActionResult GetAllShowsOfMovie(string cityName, int movieId)
        {
            return Ok(bookingService.GetAllShowsOfMovie(cityName,movieId));
        }

        [HttpGet("{cityName}/shows/{showId}")]
        public ActionResult GetAvailableSeatsInShow(string cityName, int showId)
        {
            return Ok(bookingService.GetAvailableSeatsInShow(cityName,showId));
        }

        [HttpPost("{cityName}/shows/{showId}/book/{seatId}")]
        public ActionResult BookSeatInShow(string cityName, int showId, int seatId)
        {
            bool rslt = bookingService.BookSeatInShow(cityName, showId, seatId);
            if (rslt)
            {
                return Ok("Ticket Booked");
            }
            else
            {
                return Ok("Not Booked");
            }
        }
    }
}
