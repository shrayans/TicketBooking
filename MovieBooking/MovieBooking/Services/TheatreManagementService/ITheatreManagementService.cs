using MovieBooking.Contracts;
namespace MovieBooking.Services.TheatreManagementService
{
    public interface ITheatreManagementService
    {
        public IEnumerable<Theatre> GetAllTheatres();

        public void CreateNewTheatre(Theatre theatre);

        public void AddScreenInTheatre(Screen screen);

        public void CreateShow(int theatreId,Show show);

    }
}
