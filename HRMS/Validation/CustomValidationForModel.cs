using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace HRMS.Validation
{
    public class CustomValidationForModel : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string inputValue = Convert.ToString(value);
                if (HasSpecialCharacter(inputValue))
                {
                    return new ValidationResult("Special characters are not allowed!!");
                }

                if (HasDigits(inputValue))
                {
                    return new ValidationResult("Digits are not allowed!!");
                }

                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Input cannot be null");
            }
        }

        private bool HasSpecialCharacter(string input)
        {
            string pattern = @"^[a-zA-Z0-9 ]+$"; // Updated pattern to include spaces and exclude special characters
            Regex regex = new Regex(pattern);
            return !regex.IsMatch(input);
        }

        private bool HasDigits(string input)
        {
            return input.Any(char.IsDigit);
        }
    }
}
