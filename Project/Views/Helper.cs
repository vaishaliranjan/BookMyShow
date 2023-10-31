
namespace Project.Views
{
    public static class Helper
    {
        public static string HideCharacter()

        {
            ConsoleKeyInfo key;
            string code = "";
            do
            {
                key = Console.ReadKey(true);
                if (Char.IsNumber(key.KeyChar) || Char.IsLetter(key.KeyChar))
                {
                    Console.Write("*");
                    code += key.KeyChar;
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return code;
        }
    }
}
