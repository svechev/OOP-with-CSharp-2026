using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorChooserPainterWithBinding
{
    [ValueConversion(typeof(double[]), typeof(SolidColorBrush))]
    public class Slr2ColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 4 &&
            byte.TryParse(values[3]?.ToString(), out byte a) &&
            byte.TryParse(values[0]?.ToString(), out byte r) &&
            byte.TryParse(values[1]?.ToString(), out byte g) &&
            byte.TryParse(values[2]?.ToString(), out byte b))
            {
                var newBackgroundColor = new SolidColorBrush(Color.FromArgb(a, r, g, b)); // generate new color
                Application.Current.Resources["BrushColor"] = newBackgroundColor; // use new color as brush color
                return newBackgroundColor   ;
            }
            return Brushes.Transparent;
            ////double output = value != null ? (double)value : 0;
            //byte r = (byte)(values[0] != null ? (byte)(double)values[0] : 0);
            //byte g = (byte)(values[1] != null ? (byte)(double)values[1] : 0);
            //byte b = (byte)(values[2] != null ? (byte)(double)values[2] : 0);
            //byte a = (byte)(values[3] != null ? (byte)(double)values[3] : 0);
           
            //// generate new color
            //SolidColorBrush backgroundColor = new SolidColorBrush();
            //backgroundColor.Color = Color.FromArgb( r, g,  b, a);
            ////Application.Current.Resources["BrushColor"] = backgroundColor; // use new color as brush color
            //return backgroundColor;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
