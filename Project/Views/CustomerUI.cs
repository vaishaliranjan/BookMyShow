using Project.ControllerInterface;
using Project.Enum;
using Project.Models;
using Project.Views;
using Project.ViewsInterface;

namespace Project.Views
{
    public class CustomerUI: ICustomerUI
    {
        public ICustomerView CustomerView { get; }
        public IAuthController AuthController { get; }

        public CustomerUI(ICustomerView customerView, IAuthController authController)
        {
            CustomerView = customerView;
            AuthController = authController;
        }
        public void CustomerPage(User customer)
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
                        CustomerPage(customer);
                        break;

                    case CustomerOptions.ViewPreviousBookings:
                        CustomerView.ViewBookings(customer);
                        CustomerPage(customer);
                        break;

                    case CustomerOptions.LogOut:
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
