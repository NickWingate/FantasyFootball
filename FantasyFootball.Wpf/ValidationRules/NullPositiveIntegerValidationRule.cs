using System;
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
            if (string.IsNullOrWhiteSpace((string)value))
            {
                result = new ValidationResult(false, $"{FieldName} cannot be empty");
            }
            else if (!uint.TryParse((string)value, out _))
            {
                result = new ValidationResult(false, $"{FieldName} must be positive integer less than 4,294,967,296");
            }
            return result;
        }
    }
}