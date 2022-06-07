using System.Text.RegularExpressions;

namespace SIMS.SecretaryView.Validation
{
    internal class NameValidationStrategy : IValidationStrategy
    {
        public bool Validate(object value)
        {
            Regex regex = new Regex(@"^[A-ZŠĐČĆŽ]+(([',. -][a-zA-ZšŠđĐčČćĆžŽ ])?[a-zA-ZšŠđĐčČćĆžŽ]*)*$");
            return regex.IsMatch(value as string);
        }
    }
}
