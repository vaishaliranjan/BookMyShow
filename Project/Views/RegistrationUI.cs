using Project.BusinessLayer;
using Project.Views;
using Project.Models;
using Project.Objects;
using Project.UILayer;

namespace Project.UI
{
    public static class RegistrationUI
    {
        public static int userIdInc = User.userIdInc;
        public static void AddNewUserUI(Role roleInput, AdminObjects admin=null)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            string name;
            while (true)
            {
                Console.Write(Message.enterName);
                name = InputValidation.NullValidation();
                bool ans=RegexValidation.isValidName(name);
                if(ans)
                {
                    break;
                }
                Console.WriteLine(Message.onlyCharacters);
            }
        username: string username = null;
        while (true)
            {
                Console.Write(Message.enterUsername);
                username = InputValidation.NullValidation();

                bool r =RegexValidation.isValidName(username);
                if (r)
                {
                    break;
                }
                Console.WriteLine(Message.onlyCharacters);
            }
            bool res= AuthManager.AuthObject.ValidateUser(username);
            if (!res)
            {
                Console.WriteLine(Message.userExists); 
                goto username;
            }
            string email = null;
            while (true)
            {
                Console.Write(Message.enterEmail);
                email = InputValidation.NullValidation();
                bool answer =RegexValidation.isValidEmail(email);
                if (answer)
                {
                    break;
                }
                Console.WriteLine(Message.entervalidEmail);
            }
            Console.Write(Message.enterPassword);
            string password = InputValidation.NullValidation();
           
            Console.ResetColor();
            var role = roleInput;
            bool result = false;
            int idOfUser = ++RegistrationUI.userIdInc;
            if (role == Role.Admin)
            {
                Admin a = new Admin(idOfUser, name, username, email, password, Role.Admin);
                AuthManager.AuthObject.Register(a, Role.Admin);
                result = true;
            }

            else if (role == Role.Customer)
            {
                Customer c = new Customer(idOfUser,name, username, email, password, Role.Customer);
                AuthManager.AuthObject.Register(c, Role.Customer);
                result = true;
            }
            else if (role == Role.Organizer)
            {
                Organizer o = new Organizer(idOfUser,name, username, email, password, Role.Organizer);
                AuthManager.AuthObject.Register(o, Role.Organizer);
                result = true;
            }
            if (result)
            {
                Message.UserAdded();
                
               
            }
            else
            {
                Console.WriteLine(Message.errorOccurred);

            }
           
        }
    }
}
