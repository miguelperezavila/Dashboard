
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Dashboard
{
    /// <summary>
    /// A converter that takes in a boolean and returns a <see cref="Visibility"/>
    /// </summary>
    public class StringToStateColorConverter : BaseValueConverter<StringToStateColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("Purple"));
            }
            else
            {
                string str = (string)value;
                if( str.Equals("ON"))
                {
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                }
                else
                {
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
                }
                
            }
                
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
