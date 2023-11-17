using Project.BusinessLayer;
using Project.Enum;
using Project.Models;
using Project.Objects;
using Project.Views;


namespace Project.UILayer
{
    internal class CustomerUI
    {

        public static void CustomerPage(CustomerObjects customer)
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
                        CustomerView.ViewEvents(customer); 
                        break;

                    case CustomerOptions.ViewPreviousBookings:
                        CustomerView.ViewBookings(customer);
                        
                        break;

                    case CustomerOptions.LogOut:
                        AuthController.AuthObject.Logout();
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
