using Project.ControllerInterface;
using Project.Helpers;
using Project.Models;
using Project.ViewsInterface;

namespace Project.Views
{
    public class AdminRemove : IAdminRemove
    {
        public IEventController EventController { get; }
        public IEventUI EventUI { get; }
        public AdminRemove(IEventController eventController, IEventUI eventUI)
        {
            EventController = eventController;
            EventUI = eventUI;
        }
        public void CancelEvent(User admin)
        {
            var events = EventController.GetAll();
            Print.ShowEvents(events);
            EventUI.CancelEvent();
        }

    }
}
