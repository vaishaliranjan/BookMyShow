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
        public static void LogException(Exception ex, string error)
        {
            string path = @"C:\Users\vranjan\OneDrive - WatchGuard Technologies Inc\Desktop\Practice\Project\Project\Files\Exceptions.txt";
            var time = DateTime.Now.ToString();    
            string text="EXCEPTION::   "+ ex.ToString() + "\n\nERROR::   " + error +"\n"+ time+"\n\n";
            File.AppendAllText(path, text);
        }
        
    }
}
