using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AlarmClockApp
{
    public class RingValidator : ValidationRule
    {
        public double MinRings { get; set; }
        public double MaxRings { get; set; }


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool res = double.TryParse(value.ToString(), out var val);
            if (res) {
                if (val >= MinRings && val <= MaxRings)
                {
                    return ValidationResult.ValidResult;
                }
                else
                {
                    return new ValidationResult(false, "Invalid value");
                }
            }
            else
            {
                return new ValidationResult(false, "Invalid input");
            }
        }
    }
}
