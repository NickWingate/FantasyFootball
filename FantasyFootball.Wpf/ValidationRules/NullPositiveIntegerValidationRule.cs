using System.Globalization;
using System.Windows.Controls;

namespace FantasyFootball.Wpf.ValidationRules
{
    public class NullPositiveIntegerValidationRule : ValidationRule
    {
        public string FieldName { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            string inputString = (value ?? string.Empty).ToString();
            if (string.IsNullOrWhiteSpace(inputString))
            {
                result = new ValidationResult(false, $"{FieldName} cannot be empty");
            }
            else if (!uint.TryParse(inputString, out _))
            {
                result = new ValidationResult(false, $"{FieldName} must be positive integer");
            }
            return result;
        }
    }
}