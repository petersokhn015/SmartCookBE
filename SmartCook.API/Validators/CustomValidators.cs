using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SmartCook.API.Validators
{
    public class CustomValidators
    {
        public bool BeAValidUsername(string username)
        {
            username = username.Replace(" ", "");
            Regex regexSymbolsNumbers = new Regex("^(?=.*?[1-9])[0-9()-]+$");

            if (username.All(Char.IsDigit))
            {
                return false;
            }
            else if (regexSymbolsNumbers.IsMatch(username))
            {
                return false;
            }
            else if (username.All(Char.IsSymbol))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool BeAValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email.Trim());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool BeAValidPassword(string password)
        {
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            return regex.IsMatch(password.Trim());
        }
    }
}
