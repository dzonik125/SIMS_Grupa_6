using System.Text.RegularExpressions;

namespace SIMS.SecretaryView.Validation
{
    public class NumberValidationStrategy : IValidationStrategy
    {
        public bool Validate(object value)
        {
            Regex regex = new Regex(@"^([0-9]+)$");
            return regex.IsMatch(value as string);
        }
    }
}
