using Project.Models;

namespace Project.Views
{
    public static class HelperClass
    {
        public static string HideCharacter()

        {
            ConsoleKeyInfo key;
            string code = "";
            do
            {
                key = Console.ReadKey(true);
                if (char.IsNumber(key.KeyChar) || char.IsLetter(key.KeyChar))
                {
                    Console.Write("*");
                    code += key.KeyChar;
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return code;
        }

        public static void PrintUsers<T>(List<T> users) where T : User
        {
            foreach (T user in users)
            {
                Console.WriteLine();

                Console.WriteLine("Id: " + user.UserId);
                Console.WriteLine("Name: " + user.Name);
                Console.WriteLine("Username: " + user.Username);
                Console.WriteLine("Email: " + user.Email);
                Console.WriteLine();

            }

        }
    }
}
