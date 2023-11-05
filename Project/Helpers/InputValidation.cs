using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views
{
    internal class InputValidation
    {
        public static int IntegerValidation()
        {
        label: Console.WriteLine();
            int input;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                return input;
            }
            catch
            {
                Message.InvalidInput();
                goto label;
            }
        }

        public static string NullValidation()
        {
        label: Console.WriteLine();
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Message.OnlyString();
                goto label;
            }
            return input;
        }
        public static DateTime DateValidation()
        {
            string userInput;
            DateTime dt;
        enterDate: Console.WriteLine("Enter date and time (yyyy-MM-ddTHH:mm): eg(2023-11-31T04:15");
            try
            {

                userInput = Console.ReadLine();
                dt = DateTime.ParseExact(userInput, "yyyy-MM-ddTHH:mm", CultureInfo.CurrentCulture);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter the date in correct format!");
                goto enterDate;
            }
        }
    }
}
