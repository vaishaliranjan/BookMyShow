using Project.BusinessLayer;
using Project.Models;
using Project.Views;
using Project.Objects;
using System.Data;
using System.Xml.Linq;

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
                User user = AuthManager.AuthObject.Login(username, password);
                Console.ResetColor();
                if (user != null)
                {
                    if (user.role == Role.Admin)
                    {
                        Admin newAdmin = new Admin(user.UserId,user.Name,
                            user.Username,
                        user.Email,
                        user.Password,
                           user.role) ;
                        
                        AdminUI.ADMINUI(new AdminObjects(newAdmin));
                        break;
                    }
                    else if (user.role == Role.Customer)
                    {
                        Customer newCustomer = new Customer(user.UserId,
                            user.Name,
                            user.Username,
                        user.Email,
                        user.Password,
                           user.role
                            )
                       ;
                        CustomerUI.CUSTOMERUI(new CustomerObjects(newCustomer));
                        break;
                    }
                    else if (user.role == Role.Organizer)
                    {
                        Organizer newOrganizer = new Organizer(user.UserId, user.Name,
                            user.Username,
                        user.Email,
                        user.Password,
                           user.role)
                        ;
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

