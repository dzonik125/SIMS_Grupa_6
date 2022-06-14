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
                return new ValidationResult(false, "Pogrešan format imena.");
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
                return new ValidationResult(false, "Pogrešan format prezimena.");
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
                return new ValidationResult(false, "Pogrešan format email adrese");
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
                return new ValidationResult(false, "Pogrešan format korisničkog imena.");
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
                return new ValidationResult(false, "Šifra mora da sadrži minimalno 6 karaktera.");
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
                return new ValidationResult(false, "Pogrešan format naziva grada.");
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
                return new ValidationResult(false, "Pogrešan format naziva države.");
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
                return new ValidationResult(false, "Možete uneti samo brojeve.");
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
                return new ValidationResult(false, "Pogrešan format naziva ulice.");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska");
            }
        }
    }
}
