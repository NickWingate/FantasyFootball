using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace FantasyFootball.Wpf.ValidationRules
{
    /// <summary>
    /// Validates whether value is empty or greater than max length
    /// </summary>
    public class StringValidationRule : ValidationRule
    {
        public int MaxLength { get; set; }
        public string FieldName { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            string inputString = (value ?? string.Empty).ToString();
            Debug.WriteLine(inputString);
            if (String.IsNullOrWhiteSpace(inputString))
            {
                result = new ValidationResult(false, $"{FieldName} cannot be empty");

            }
            else if (inputString.Length > MaxLength)
            {
                result = new ValidationResult(false, $"{FieldName} must be less than {MaxLength} characters");
            }
            return result;
        }
    }
}
