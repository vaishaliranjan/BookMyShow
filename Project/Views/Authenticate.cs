using Project.BusinessLayer;
using Project.Views;


namespace Project.UILayer
{
    public static class Authenticate
    {
        public static void LoginUI()
        {
            while (true)
            {
                Role roleOfUser;
                Console.Write("Enter username: ");
                string username = InputValidation.NullValidation();
                Console.Write("Enter password: ");
                string password = Helper.HideCharacter();
                string userRole = AuthManager<User>.AuthObject.Login(username, password);
                Console.ResetColor();
                    if (userRole=="Admin")
                    {
                        AdminUI.ADMINUI(username);
                        break;  
                    }
                    else if (userRole == "Customer")
                    {
                        CustomerUI.CUSTOMERUI(username);
                        break;
                    }
                    else if (userRole == "Organizer")
                    {
                        OrganizerUI.ORGANIZERUI(username);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong credentials");
                        continue;
                    }   
                }
            }
        }
    }

