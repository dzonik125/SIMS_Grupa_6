using System.Text.RegularExpressions;

namespace SIMS.SecretaryView.Validation
{
    public class EmailValidationStrategy : IValidationStrategy
    {
        public bool Validate(object value)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            return regex.IsMatch(value as string);
        }
    }
}
