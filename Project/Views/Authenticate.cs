using Project.BusinessLayer;
using Project.Helper;
using Project.Models;
using Project.Views;
using Project.Objects;

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
                string password =HelperClass.HideCharacter();
                User user = AuthManager<User>.AuthObject.Login(username, password);
                Console.ResetColor();
                if (user != null)
                {
                    if (user.role == Role.Admin)
                    {
                        Admin newAdmin = new Admin() { UserId = user.UserId,
                        Name = user.Name,
                        Username = user.Username,
                        Email = user.Email,
                        role = user.role,
                        Password = user.Password
                    };
                        
                        AdminUI.ADMINUI(new AdminObjects(newAdmin));
                        break;
                    }
                    else if (user.role == Role.Customer)
                    {
                        Customer newCustomer = new Customer()
                        {
                            UserId = user.UserId,
                            Name = user.Name,
                            Username = user.Username,
                            Email = user.Email,
                            role = user.role,
                            Password = user.Password
                        };
                        CustomerUI.CUSTOMERUI(new CustomerObjects(newCustomer));
                        break;
                    }
                    else if (user.role == Role.Organizer)
                    {
                        Organizer newOrganizer = new Organizer()
                        {
                            UserId = user.UserId,
                            Name = user.Name,
                            Username = user.Username,
                            Email = user.Email,
                            role = user.role,
                            Password = user.Password
                        };
                        OrganizerUI.ORGANIZERUI(new OrganizerObjects(newOrganizer));
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(Message.wrongCredentials);
                    continue;
                }   
                }
            }
        }
    }

