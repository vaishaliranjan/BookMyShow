using Project.BusinessLayer;
using Project.Views;
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
            
            
           
            while (true)
            {
                Console.Write(Message.ChooseNum);
                input = (OrganizerUIOptions)InputValidation.IntegerValidation();
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
                        AuthManager.AuthObject.Logout();
                        break;

                    default:
                        Console.WriteLine(Message.invalidInput);
                        continue; 
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
            
            EventUI.ViewEventsUI(Role.Organizer, organizer.realOrganizerObject.Username);
           
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
                            OrganizerUI.ORGANIZERUI(organizer);
                            break;

                        default:
                            Console.WriteLine(Message.invalidInput);
                            continue;
                    }
                }
                            
            }
            
        }

        

       
    }
}
