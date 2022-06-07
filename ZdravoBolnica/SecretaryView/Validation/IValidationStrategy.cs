namespace SIMS.SecretaryView.Validation
{
    public interface IValidationStrategy
    {
        bool Validate(object value);
    }
}
