using System.Text.RegularExpressions;

namespace SIMS.SecretaryView.Validation
{
    public class PasswordValidationStrategy : IValidationStrategy
    {
        public bool Validate(object value)
        {
            Regex regex = new Regex(@"^.{6,}$");
            return regex.IsMatch(value as string);
        }
    }
}
