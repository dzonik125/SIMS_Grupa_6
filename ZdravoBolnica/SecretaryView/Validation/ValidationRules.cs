using System.Globalization;
using System.Windows.Controls;

namespace SIMS.SecretaryView.Validation
{
    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                ValidationContext validationContext = new ValidationContext();
                validationContext.SetStrategy(new NameValidationStrategy());
                if (validationContext.Validate(text)) return new ValidationResult(true, null);
                return new ValidationResult(false, "Loš format");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }

    public class SurnameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                ValidationContext validationContext = new ValidationContext();
                validationContext.SetStrategy(new NameValidationStrategy());
                if (validationContext.Validate(text)) return new ValidationResult(true, null);
                return new ValidationResult(false, "Loš format");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                ValidationContext validationContext = new ValidationContext();
                validationContext.SetStrategy(new EmailValidationStrategy());
                if (validationContext.Validate(text)) return new ValidationResult(true, null);
                return new ValidationResult(false, "Loš format");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }

    public class UsernameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                ValidationContext validationContext = new ValidationContext();
                validationContext.SetStrategy(new UsernameValidationStrategy());
                if (validationContext.Validate(text)) return new ValidationResult(true, null);
                return new ValidationResult(false, "Loš format");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }

    public class PasswordValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                ValidationContext validationContext = new ValidationContext();
                validationContext.SetStrategy(new PasswordValidationStrategy());
                if (validationContext.Validate(text)) return new ValidationResult(true, null);
                return new ValidationResult(false, "Loš format");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }
    public class CityValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                ValidationContext validationContext = new ValidationContext();
                validationContext.SetStrategy(new NameValidationStrategy());
                if (validationContext.Validate(text)) return new ValidationResult(true, null);
                return new ValidationResult(false, "Loš format");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }

    public class StateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                ValidationContext validationContext = new ValidationContext();
                validationContext.SetStrategy(new NameValidationStrategy());
                if (validationContext.Validate(text)) return new ValidationResult(true, null);
                return new ValidationResult(false, "Loš format");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }

    public class OnlyNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                ValidationContext validationContext = new ValidationContext();
                validationContext.SetStrategy(new NumberValidationStrategy());
                if (validationContext.Validate(text)) return new ValidationResult(true, null);
                return new ValidationResult(false, "Loš format");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }


    public class DateValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                ValidationContext validationContext = new ValidationContext();
                validationContext.SetStrategy(new DateValidationStrategy());
                if (validationContext.Validate(text)) return new ValidationResult(true, null);
                return new ValidationResult(false, "Format datuma: dd.mm.gggg.");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }



    public class AddressValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                ValidationContext validationContext = new ValidationContext();
                validationContext.SetStrategy(new NameValidationStrategy());
                if (validationContext.Validate(text)) return new ValidationResult(true, null);
                return new ValidationResult(false, "Loš format");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }
}
