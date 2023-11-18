using Project.Enum;
using Project.Models;
using Project.ViewsInterface;
using Project.ControllerInterface;

namespace Project.Views
{
    public class OrganizerUI: IOrganizerUI
    {
        public IEventUI EventUI { get; }
        public IOrganizerView OrganizerView { get; }
        public IAuthController AuthController { get; }

        public OrganizerUI(IEventUI eventUI,IOrganizerView organizerView, IAuthController authController)
        {
            EventUI = eventUI;
            OrganizerView = organizerView;
            AuthController = authController;
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
                        EventUI.CancelEvent();
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
         



        

    }
}
