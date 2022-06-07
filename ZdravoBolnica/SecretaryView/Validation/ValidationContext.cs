namespace SIMS.SecretaryView.Validation
{
    public class ValidationContext
    {
        private IValidationStrategy validationStrategy;

        public ValidationContext() { }

        public ValidationContext(IValidationStrategy validationStrategy)
        {
            this.validationStrategy = validationStrategy;
        }

        public void SetStrategy(IValidationStrategy validationStrategy)
        {
            this.validationStrategy = validationStrategy;
        }

        public bool Validate(object value)
        {
            return validationStrategy.Validate(value);
        }

    }
}
