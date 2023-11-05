using Project.BusinessLayer;
using Project.Views;
using System;
using Project.Enum;
using Project.Models;


namespace Project.UILayer
{
    internal class OrganizerUI
    {
        
        public static void ORGANIZERUI(OrganizerObjects organizer)
        {
            Message.OrganizerPage();
            OrganizerUIOptions input;
            Console.Write(Message.ChooseNum);
            input = (OrganizerUIOptions)InputValidation.IntegerValidation();
           
            while (true)
            {
                switch (input)
                {
                    case OrganizerUIOptions.CreateEvent:
                        CreateEvent(organizer);
                        break;

                    case OrganizerUIOptions.ViewPreviousEvents:
                        ViewPreviousEventsUI(organizer);
                        break;

                    case OrganizerUIOptions.CancelEvent:
                        CancelEvent(organizer);
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
         static void CancelEvent(OrganizerObjects organizer)
        {
            EventUI.ViewEventsUI(Role.Organizer, organizer.realOrganizerObject.Username);
            EventUI.CancelEventUI();
            OrganizerUI.ORGANIZERUI(organizer);
        }

         static void CreateEvent(OrganizerObjects organizer)
        {
            EventUI.CreateEventUI(Role.Organizer, organizer.realOrganizerObject);
            OrganizerUI.ORGANIZERUI(organizer);

        }
        public static void ViewPreviousEventsUI(OrganizerObjects organizer) 
        {
            Message.ViewEvents();
            EventUI.ViewEventsUI(Role.Organizer, organizer.realOrganizerObject.Username);
            Message.PressToExit();
            while (true)
            {
                OrganizerUIOptions ip;
                while (true)
                {
                    ip = (OrganizerUIOptions)(InputValidation.IntegerValidation());
                    switch (ip)
                    {
                        case OrganizerUIOptions.Back:
                            OrganizerUI.ORGANIZERUI(organizer);
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
