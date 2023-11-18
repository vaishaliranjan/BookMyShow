using Project.Enum;
using Project.ViewsInterface;

namespace Project.Views
{
    public class HomePage: IHomePage
    {
        public IAuthenticate Authenticate { get; }
        public IRegistration Register { get; }
        public HomePage(IAuthenticate authenticate, IRegistration register)
        {
            Authenticate = authenticate;  
            Register = register;
        }

        public void Run()
        {
            Message.HomePage();           
            while (true)
            {
                Console.Write(Message.ChooseNum);
                HomePageOptions input;
                input = (HomePageOptions)InputValidation.IntegerValidation();
                switch (input)
                {
                    case HomePageOptions.Login:
                        Console.ResetColor();
                        Authenticate.Login();
                        break;

                    case HomePageOptions.Signup:
                        Console.ResetColor();
                        Register.RegisterUser(Role.Customer);
                        Authenticate.Login();
                        break;

                    case HomePageOptions.Exit:
                        Environment.Exit(0);
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