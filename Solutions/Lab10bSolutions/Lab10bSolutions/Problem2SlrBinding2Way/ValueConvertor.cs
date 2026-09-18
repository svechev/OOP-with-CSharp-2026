using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Zadacha2
{
    [ValueConversion(typeof(double), typeof(string))]
    class ValueConvertor : IValueConverter
    {
        // converts double Value of Slider into string Content of TextBox
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double output = value != null ? (double)value : 0;
            return string.Format("{0:F2}", output);
        }

        // converts string Content of TextBox into double Value of Slider 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = double.TryParse((string)value, out var output);
            return result?output:0;
        }
    }
}
