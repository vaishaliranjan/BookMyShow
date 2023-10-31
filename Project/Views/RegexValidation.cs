
using System.Text.RegularExpressions;


namespace Project.Views
{
    internal class RegexValidation
    {
        private static string _emailRegex;
        private static string _nameRegex;

        static RegexValidation()
        {
            _emailRegex= @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            _nameRegex= @"[a-z]{3}";
        }
        public static bool isValidEmail(string email)
        {
            bool res = Regex.IsMatch(email, _emailRegex, RegexOptions.IgnoreCase);
            return res;
        }
        public static bool isValidName(string name)
        {
            bool res = Regex.IsMatch(name, _nameRegex, RegexOptions.IgnoreCase);
            return res;
        }
    }
}
