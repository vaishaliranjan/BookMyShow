using Project.Enum;
using Project.Models;
using Project.ViewsInterface;
using Project.ControllerInterface;
using Project.Controller;
using Project.Helpers;

namespace Project.Views
{
    public class OrganizerUI: IOrganizerUI
    {
        public IEventUI EventUI { get; }
        public IOrganizerView OrganizerView { get; }
        public IAuthController AuthController { get; }
        public IEventController EventController { get; }

        public OrganizerUI(IEventUI eventUI,IOrganizerView organizerView, IAuthController authController, IEventController eventController)
        {
            EventUI = eventUI;
            OrganizerView = organizerView;
            AuthController = authController;
            EventController = eventController;
        }

        public void OrganizerPage(User organizer)
        {
            Message.OrganizerPage();
            OrganizerUIOptions input;
            while (true)
            {
                Console.Write(Message.ChooseNum);
                input = (OrganizerUIOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    
                    case OrganizerUIOptions.CreateEvent:
                        EventUI.CreateEvent(organizer.Username);
                        OrganizerPage(organizer);
                        break;

                    case OrganizerUIOptions.ViewPreviousEvents:
                        OrganizerView.ViewEvents(organizer);
                        OrganizerPage(organizer);
                        break;

                    case OrganizerUIOptions.CancelEvent:
                        CancelEvent(organizer);
                        OrganizerPage(organizer);
                        break;

                    case OrganizerUIOptions.LogOut:
                        AuthController.Logout();
                        break;

                    default:
                        Console.WriteLine(Message.InvalidInputMessage);
                        continue; 
                }
                break;
            }
            

        }

        public void CancelEvent(User organizer)
        {
            var events = EventController.GetOrganizerEvents(organizer.Username);
            Print.ShowEvents(events);
            EventUI.CancelEvent();
        }




    }
}
