using Project.Controller;
using Project.ControllerInterface;
using Project.Models;

namespace Project.Views
{
    public static class HelperClass
    {
        static int artistId = Artist.ArtistIdInc;
        static int venueId = Venue.VenueIdInc;
        public static string HideCharacter()
        {
            var input = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && input.Length > 0)
                {
                    Console.Write("\b \b");
                    input = input[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    input += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            return input;
        }
        public static void LogException(Exception ex, string error)
        {
            string path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Project\Files\Exceptions.txt";
            var time = DateTime.Now.ToString();    
            string text="EXCEPTION::   "+ ex.ToString() + "\n\nERROR::   " + error +"\n"+ time+"\n\n";
            File.AppendAllText(path, text);
        }

        public static string EnterUsername()
        {
            Console.Write(Message.EnterUsername);
            var username = InputValidation.StringValidation();
            return username;
        }

        public static string EnterPassword()
        {
            Console.Write(Message.EnterPassword);
            var password = HelperClass.HideCharacter();
            Console.WriteLine();
            return password;
        }

        public static string EnterName()
        {
            Console.WriteLine();
            string name;
            while (true)
            {
                Console.Write(Message.EnterName);
                name = InputValidation.StringValidation();
                bool ans = RegexValidation.IsValidName(name);
                if (ans)
                {
                    break;
                }
                Console.WriteLine(Message.OnlyCharacters);
            }
            return name;
        }

        public static string RegisterEnterUsername()
        {
            IAuthController authController = AuthController.AuthObject;
            string username;
            while (true)
            {
                Console.Write(Message.EnterUsername);
                username = InputValidation.StringValidation();

                bool r = RegexValidation.IsValidUsername(username);
                if (r)
                {
                    bool res = authController.ValidateUser(username);
                    if (!res)
                    {
                        Console.WriteLine(Message.UserAlreadyExists);
                        continue;
                    }
                    break;
                }
                Console.WriteLine(Message.OnlyCharacters);
            }
            return username;

        }




        public static string EnterEmail()
        {
            string email;
            while (true)
            {
                Console.Write(Message.EnterEmail);
                email = InputValidation.StringValidation();
                bool answer = RegexValidation.IsValidEmail(email);
                if (answer)
                {
                    break;
                }
                Console.WriteLine(Message.EnterValidEmail);
            }
            return email;
        }

        public static string RegisterEnterPassword()
        {

            string password;
            while (true)
            {
                Console.Write(Message.EnterPassword);
                password = InputValidation.StringValidation();
                bool answer = RegexValidation.IsValidPassword(password);
                if (answer)
                {
                    break;
                }
                Console.WriteLine(Message.EnterValidPassword);
            }
            return password;
        }


        public static Venue EnterVenueDetails()
        {
            Console.Write(Message.EnterPlace);
            var place = InputValidation.StringValidation();
            var venue = new Venue(++venueId, place);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            return venue;
        }
        public static Artist EnterArtistDetails()
        {
            Console.Write(Message.EnterName);
            string name = InputValidation.StringValidation();
            DateTime dt = InputValidation.DateValidation();
            var artist = new Artist(++artistId, name, dt);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            return artist;
        }
             

        public static string EnterEventName()
        {
            Console.Write(Message.EnterEventName);
            var eventName = InputValidation.StringValidation();
            return eventName;
        }
        public static int EnterNumberOfTickets()
        {
            Console.Write(Message.EnterNumOfTickets);
            var tickets = InputValidation.IntegerValidation();
            return tickets;
        }

        public static double EnterPricePerTicket()
        {
            Console.Write(Message.EnterPricePerTicket);
            double price = InputValidation.FloatValidation();
            return price;
        }
    }
}
