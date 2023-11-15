using Project.BusinessLayer;
using Project.Views;
using Project.Enum;
using Project.Models;


namespace Project.UILayer
{
    internal class OrganizerUI
    {
        
        public static void OrganizerPage(OrganizerObjects organizer)
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
                        ViewEvents(organizer);
                        break;

                    case OrganizerUIOptions.CancelEvent:
                        CancelEvent(organizer);
                        break;

                    case OrganizerUIOptions.LogOut:
                        AuthController.AuthObject.Logout();
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
            ViewEvents(organizer);
            EventUI.CancelEvent(organizer.eventContoller);
            OrganizerPage(organizer);
        }

         static void CreateEvent(OrganizerObjects organizer)
        {
            EventUI.CreateEvent(organizer.realOrganizerObject);
            OrganizerPage(organizer);
        }



        public static void ViewEvents(OrganizerObjects organizer)
        {
            var allEvents = organizer.eventContoller.GetOrganizerEvents(organizer.realOrganizerObject.Username);
            EventUI.ShowEvents(allEvents);
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
                            OrganizerUI.OrganizerPage(organizer);
                            break;

                        default:
                            Console.WriteLine(Message.invalidInput);
                            continue;
                    }
                    break;
                }
                break;  
            }
        }

    }
}
