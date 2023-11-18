using Project.ControllerInterface;
using Project.Enum;
using Project.Helpers;
using Project.Models;
using Project.ViewsInterface;


namespace Project.Views
{
    public class OrganizerView:IOrganizerView
    {
        public IEventController EventController { get; }
        public OrganizerView(IEventController eventController)
        {
            EventController = eventController;
        }
        public void ViewEvents(User organizer)
        {
            var allEvents = EventController.GetOrganizerEvents(organizer.Username);
            Print.ShowEvents(allEvents);
            while (true)
            {
                OrganizerUIOptions ip;
                while (true)
                {
                    Message.PressToExit();
                    ip = (OrganizerUIOptions)(InputValidation.IntegerValidation());
                    switch (ip)
                    {
                        case OrganizerUIOptions.Back:
                            break;

                        default:
                            Console.WriteLine(Message.InvalidInputMessage);
                            continue;
                    }
                    break;
                }
                break;
            }
        }
    }
}
