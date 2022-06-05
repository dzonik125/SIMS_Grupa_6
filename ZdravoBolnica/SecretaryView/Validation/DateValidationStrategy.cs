using System.Text.RegularExpressions;

namespace SIMS.SecretaryView.Validation
{
    public class DateValidationStrategy : IValidationStrategy
    {
        public bool Validate(object value)
        {
            Regex regex = new Regex("(([1-2][0-9])|([1-9])|(3[0-1])).((1[0-2])|([1-9])).[0-9]{4}.");
            return regex.IsMatch(value as string);
        }
    }
}
