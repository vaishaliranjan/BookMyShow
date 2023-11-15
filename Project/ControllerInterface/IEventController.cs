using Project.Models;


namespace Project.ControllerInterface
{
    public interface IEventController : IGetAll<Event>, IGetByID<Event>, IAdd<Event>, IDeleteById
    {
        List<Event> GetOrganizerEvents(string username);
        public void DecrementTicket(Event bookedEvent, int numOfTickets);
    }
}
