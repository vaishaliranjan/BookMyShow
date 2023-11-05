using Project.BusinessLayer;
using Project.Controller;
using Project.Enum;
using Project.Models;
using Project.Objects;
using Project.Views;


namespace Project.UILayer
{
    internal class CustomerUI
    {

        public static void CUSTOMERUI(CustomerObjects customer)
        {
            Message.CustomerPage();
            Console.Write(Message.ChooseNum);
            
            while (true)
            {
                CustomerOptions input;                
                input = (CustomerOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case CustomerOptions.ViewEvents:
                        CustomerViewEventsUI(customer); 
                        break;

                    case CustomerOptions.ViewPreviousBookings:
                        CustomerViewBookingsUI(customer);
                        
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
        public static void CustomerViewBookingsUI(CustomerObjects customer)
        {
            BookingsUI.ViewBookingsUI(Role.Customer, customer.realCustomerObject.Username,customer.bookingController);
            Message.PressToExit();
            Console.Write(Message.ChooseNum);
            while (true)
            {

                BookingsOptions input;
                input = (BookingsOptions)InputValidation.IntegerValidation();

                switch (input)
                {

                    case BookingsOptions.Exit:
                        Console.WriteLine();
                        CustomerUI.CUSTOMERUI(customer);
                        break;


                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }

        }
        //to be removed
        public static void CustomerViewEventsUI(CustomerObjects customer)
        {
            EventUI.ViewEventsUI(Role.Customer);
            Message.CustomerViewEvents();
            Console.Write(Message.ChooseNum);
            
            while (true)
            {

                CustomerUIOpitonsViewEvents ip;
                ip = (CustomerUIOpitonsViewEvents)InputValidation.IntegerValidation();
                switch (ip)
                {
                    case CustomerUIOpitonsViewEvents.BookTicket:
                        BookTicket(customer);
                        CustomerUI.CUSTOMERUI(customer);
                        break;

                    case CustomerUIOpitonsViewEvents.Exit:
                        CustomerUI.CUSTOMERUI(customer);
                        break;

                    default:
                        Message.InvalidInput();
                        continue;
                }
                break;
            }
           
        }

        static void BookTicket(CustomerObjects customer)
        {
            BookingsUI.BookTicketsUI(customer.realCustomerObject);
            

        }
    }
}
