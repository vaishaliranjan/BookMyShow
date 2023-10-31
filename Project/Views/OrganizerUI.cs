using Project.BusinessLayer;
using Project.Views;
using System;
using Project.Enum;

namespace Project.UILayer
{
    internal class OrganizerUI
    {
        
        public static void ORGANIZERUI(string username)
        {
            Message.OrganizerPage();
            OrganizerUIOptions input;
            Console.Write("Choose any number: ");
            input = (OrganizerUIOptions)InputValidation.IntegerValidation();
           
            while (true)
            {
                switch (input)
                {
                    case OrganizerUIOptions.CreateEvent:
                        EventUI.CreateEventUI(username, Role.Organizer);
                        break;

                    case OrganizerUIOptions.ViewPreviousEvents:
                        ViewPreviousEventsUI(username, Role.Organizer);
                        break;

                    case OrganizerUIOptions.CancelEvent:
                        EventUI.CancelEventUI(username, Role.Organizer);
                        break;

                    case OrganizerUIOptions.LogOut:
                        AuthManager<User>.AuthObject.Logout();
                        break;

                    default:
                        Message.InvalidInput();
                        continue; ;
                }
                break;
            }
            

        }

        

        public static void ViewPreviousEventsUI(string username, Role role) 
        {
            Event.ViewEvents(username, role);
            Console.Write("Choose any number: ");
            while (true)
            {
                Message.OrganizerViewEvents();
                OrganizerUIOptions ip;
                while (true)
                {
                    ip = (OrganizerUIOptions)(InputValidation.IntegerValidation());
                    switch (ip)
                    {
                        case OrganizerUIOptions.Back:
                            OrganizerUI.ORGANIZERUI(username);
                            break;

                        default:
                            Message.InvalidInput();
                            continue;
                    }
                }
                            
            }
            
        }

        

       
    }
}
