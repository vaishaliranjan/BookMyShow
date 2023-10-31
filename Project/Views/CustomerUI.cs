using Project.BusinessLayer;
using Project.Enum;
using Project.Views;


namespace Project.UILayer
{
    internal class CustomerUI
    {

        public static void CUSTOMERUI(string username)
        {
            Console.Write("Choose any number: ");
            Message.CustomerPage();
            while (true)
            {
                CustomerOptions input;                
                input = (CustomerOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case CustomerOptions.ViewEvents:
                       CustomerViewEventsUI(username); 
                        break;

                    case CustomerOptions.ViewPreviousBookings:
                        BookingsUI.ViewBookingsUI(username, Role.Customer);
                        break;

                    case CustomerOptions.LogOut:
                        AuthManager<User>.AuthObject.Logout();
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
        }
        public static void CustomerViewEventsUI(string username)
        {
            Event.ViewEvents(username, Role.Customer);
            Console.Write("Choose any number: ");
            Message.CustomerViewEvents();
            while (true)
            {

                CustomerUIOpitonsViewEvents ip;
                ip = (CustomerUIOpitonsViewEvents)InputValidation.IntegerValidation();
                switch (ip)
                {
                    case CustomerUIOpitonsViewEvents.BookTicket:
                        BookingsUI.BookTicketsUI(username, Role.Customer);
                        break;

                    case CustomerUIOpitonsViewEvents.Exit:
                        CustomerUI.CUSTOMERUI(username);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
           
        }
    }
}
