using Microsoft.AspNetCore.Mvc;
using MovieBooking.Contracts;

namespace MovieBooking.Services.TheatreManagementService
{
    [ApiController]
    [Route("admin/TheatreManagement")]
    public class TheatreManagementController : ControllerBase
    {
        private ITheatreManagementService theatreManagementService;

        public TheatreManagementController(ITheatreManagementService theatreManagementService)
        {
            this.theatreManagementService = theatreManagementService;
        }

        [HttpGet("listAllTheatres")]
        public ActionResult Get()
        {
            return Ok(theatreManagementService.GetAllTheatres());
        }

        [HttpPost("createNewTheatre")]
        public ActionResult CreateNewTheatre(Theatre theatre)
        {
            theatreManagementService.CreateNewTheatre(theatre);
            return Ok();
        }

        [HttpPost("addScreenInTheatre")]
        public ActionResult AddScreenInTheatre(Screen screen)
        {
            theatreManagementService.AddScreenInTheatre(screen);
            return Ok();
        }

        [HttpPost("createShow")]
        public ActionResult CreateShow(int TheatreId, Show show)
        {
            theatreManagementService.CreateShow(TheatreId, show);
            return Ok();
        }
    }
}
