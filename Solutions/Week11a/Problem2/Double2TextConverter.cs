using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Problem2
{
    [ValueConversion(typeof(double), typeof(string))]
    public class Double2TextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0.00;
            }
            double input = (double)value;
            return $"{input:F2}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = double.TryParse((string)value, out double resultValue);
            if (!result)
            {
                return 0.0;
            }
            return resultValue;
        }
    }
}
