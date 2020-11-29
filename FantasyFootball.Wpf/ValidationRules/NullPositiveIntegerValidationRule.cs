using System;
using System.Globalization;
using System.Windows.Controls;

namespace FantasyFootball.Wpf.ValidationRules
{
    /// <summary>
    /// Validates whether the valie is not null, and is non negative(i.e. postive numbers incliding 0) 
    /// </summary>
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