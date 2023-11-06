using Project.BusinessLayer;
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
           
            
            while (true)
            {
                Console.Write(Message.ChooseNum);
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
                        AuthManager.AuthObject.Logout();
                        break;

                    default:
                        Console.WriteLine(Message.invalidInput);
                        continue;
                }
                break;
            }
        }
        public static void CustomerViewBookingsUI(CustomerObjects customer)
        {
            BookingsUI.ViewBookingsUI(Role.Customer, customer.realCustomerObject.Username,customer.bookingController);
            
            
            while (true)
            {
                Message.PressToExit();
                BookingsOptions input;
                input = (BookingsOptions)InputValidation.IntegerValidation();

                switch (input)
                {

                    case BookingsOptions.Exit:
                        Console.WriteLine();
                        CustomerUI.CUSTOMERUI(customer);
                        break;


                    default:
                        Console.WriteLine(Message.invalidInput);
                        continue;
                }
                break;
            }

        }
        
        public static void CustomerViewEventsUI(CustomerObjects customer)
        {
            EventUI.ViewEventsUI(Role.Customer);
            Message.CustomerViewEvents();
            
            
            while (true)
            {
                Console.Write(Message.ChooseNum);
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
                        Console.WriteLine(Message.invalidInput);
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
