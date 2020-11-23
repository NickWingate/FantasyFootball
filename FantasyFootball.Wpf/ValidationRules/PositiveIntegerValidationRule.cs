using System.Globalization;
using System.Windows.Controls;

namespace FantasyFootball.Wpf.ValidationRules
{
    public class PositiveIntegerValidationRule : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            string inputString = (value ?? string.Empty).ToString();
            if (!uint.TryParse(inputString, out _))
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            return result;
        }
    }
}