using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataBindingExample7
{
    public class MyValidationRule : ValidationRule
    {
        private string? validName;
        public string? ValidName
        {
            get { return validName; }
            set { validName = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {   // parameter value holds the  data subject for validation
            string enteredName = value?.ToString() ?? string.Empty;
             
            if (enteredName == validName)
            {  // the rule fails
                return new ValidationResult(false, "Hey, That's random name!");
            }
            else
            {   // the rule passed
                return  ValidationResult.ValidResult;
            }
        }

    }
    public class MyValidationRuleAge : System.Windows.Controls.ValidationRule
    {
        private int minimumAge;
        private int maximumAge;

        public int MaximumAge
        {
            get { return maximumAge; }
            set { maximumAge = value; }
        }

        public int MinimumAge
        {
            get { return minimumAge; }
            set { minimumAge = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {   // parameter value holds the  data subject for validation

            bool result = int.TryParse((string)value, out var enteredAge);
            if (!result) enteredAge = MinimumAge;

            if (enteredAge < MinimumAge || enteredAge > MaximumAge)
            {  // the rule fails
                return new ValidationResult(false, "Hey, That's invalid age!");
            }
            else
            {   // the rule passed
                return  ValidationResult.ValidResult;
            }
        }
    }
}
