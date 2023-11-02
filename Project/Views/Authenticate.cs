using Project.BusinessLayer;
using Project.Models;
using Project.Views;


namespace Project.UILayer
{
    public static class Authenticate
    {
        public static void LoginUI()
        {
            while (true)
            {
                Console.Write(Message.enterUsername);
                string username = InputValidation.NullValidation();
                Console.Write(Message.enterPassword);
                string password = Helper.HideCharacter();
                User user = AuthManager<User>.AuthObject.Login(username, password);
                Console.ResetColor();
                    if (user.role==Role.Admin)
                    {
                        AdminUI.ADMINUI((Admin)user);
                        break;  
                    }
                    else if (user.role == Role.Customer)
                    {
                        CustomerUI.CUSTOMERUI(username);
                        break;
                    }
                    else if (user.role == Role.Organizer)
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

