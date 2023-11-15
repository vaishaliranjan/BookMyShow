using System.Globalization;

namespace Project.Views
{
    public class InputValidation
    {
        public static int IntegerValidation()
        {
            int input;
            while (true)
            {
                Console.WriteLine();
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    return input;
                }
                catch(Exception ex) 
                {
                    Message.InvalidInput();
                    HelperClass.LogException(ex, "Invalid input");
                    continue;
                }
            }
        }
        public static double FloatValidation()
        {
            double input;
            while (true)
            {
                Console.WriteLine();
                
                try
                {
                    input = Convert.ToDouble(Console.ReadLine());
                    return input;
                }
                catch(Exception ex) 
                {
                    Message.InvalidInput();
                    HelperClass.LogException(ex, "Invalid input");
                    continue;
                }
            }
        }

        public static string StringValidation()
        {
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Message.OnlyString();
                        continue;
                    }
                    return input;
                }
                catch(Exception ex) 
                {
                    Message.OnlyString();
                    HelperClass.LogException(ex, "Invalid input");
                    continue;
                }
            }
        }
        public static DateTime DateValidation()
        {
            string userInput;
            DateTime dt;
            while (true)
            {
                Console.WriteLine("Enter date and time (yyyy-MM-ddTHH:mm): eg(2023-11-31T04:15");
                try
                {

                    userInput = Console.ReadLine();
                    dt = DateTime.ParseExact(userInput, "yyyy-MM-ddTHH:mm", CultureInfo.CurrentCulture);
                    return dt;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Enter the date in correct format!");
                    HelperClass.LogException(ex, "Invalid date and time");
                    continue;
                }
            }
        }
    }
}
