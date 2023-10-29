using Project.BusinessLayer;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UILayer
{
    internal class OrganizerUI
    {
        enum OrganizerUIOptions
        {
            CreateEvent=1,
            ViewPreviousEvents = 2,
            CancelEvent =3,
            LogOut =4
        }
        public static void ORGANIZERUI(string username)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*************************************************************");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                     ORGANIZERPAGE                         *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*                                                           *");
            Console.WriteLine("*************************************************************");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1. Create an event");
            Console.WriteLine("2. View previously created events");
            Console.WriteLine("3. Cancel an event");
            Console.WriteLine("4. Logout");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter any one: ");
            int input = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                switch (input)
                {
                    case (int)OrganizerUIOptions.CreateEvent:
                        EventUI.CreateEventUI(username, Role.Organizer);
                        break;

                    case (int)OrganizerUIOptions.ViewPreviousEvents:
                        ViewPreviousEventsUI(username, Role.Organizer);
                        break;

                    case (int)OrganizerUIOptions.CancelEvent:
                        EventUI.CancelEventUI(username, Role.Organizer);
                        break;

                    case (int)OrganizerUIOptions.LogOut:
                        AuthManager<User>.AuthObject.Logout();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid Input!!!");
                        continue; ;
                }
                break;
            }
            

        }

        

        public static void ViewPreviousEventsUI(string username, Role role) 
        {
            Event.ViewEvents(username, role);
            while (true)
            {
                Console.WriteLine();
                Console.Write("Press 0 to exit: ");
                var ip = Convert.ToInt32(Console.ReadLine());
                if (ip == 0)
                {
                    OrganizerUI.ORGANIZERUI(username);
                    break;
                }
                Console.WriteLine("Invalid Input!!!");
            }
            
        }

        

       
    }
}
