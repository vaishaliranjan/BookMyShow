
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace Project.Views
{
    public class RegexValidation
    {
        private readonly static string _emailRegex;
        private readonly static string _alphaRegex;
        private readonly static string _alphaNumericRegex;
        private readonly static string _passwordRegex;
        static RegexValidation()
        {
            _emailRegex = @"^[^@\s]+@[^@\s]+\.([^@\s])";
            _alphaRegex = @"^[a-zA-Z]+$";
            _alphaNumericRegex = @"^[a-zA-Z][a-zA-Z0-9]+$";
            _passwordRegex = @"^\S";
        }
        public static bool IsValidEmail(string email)
        {
            bool result = Regex.IsMatch(email, _emailRegex, RegexOptions.IgnoreCase);
            return result;
        }
        public static bool IsValidName(string name)
        {
            bool result = Regex.IsMatch(name, _alphaRegex, RegexOptions.IgnoreCase);
            return result;
        }

        public static bool IsValidUsername(string userName)
        {
            bool result = Regex.IsMatch(userName, _alphaNumericRegex, RegexOptions.IgnoreCase);
            return result;
        }
        public static bool IsValidPassword(string password)
        {
            bool result = Regex.IsMatch(password, _passwordRegex, RegexOptions.IgnoreCase);
            return result;
        }
    }
}
