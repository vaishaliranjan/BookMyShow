﻿

namespace Project.Controller
{
    internal class Error
    {
        public static void UnexpectedError()
        {
            Console.WriteLine();
            Console.WriteLine("An unexpected error occurred!");
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
