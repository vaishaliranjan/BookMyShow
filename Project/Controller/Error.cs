

namespace Project.Controller
{
    internal class Error
    {
        public static void Invalid(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.WriteLine();
            Console.ResetColor();
        }
        public static void NotFound(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("No "+ message+ " found!!");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
