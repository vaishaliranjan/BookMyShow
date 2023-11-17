using Project.Models;

namespace Project.Views
{
    public static class HelperClass
    {
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
        
    }
}
