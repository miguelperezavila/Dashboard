
using System;
using System.Diagnostics;
using System.Globalization;

namespace Dashboard
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Find the aprropiate page
            switch((ApplicationPage) value )
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.Control:
                    return new ControlPage();

                case ApplicationPage.Settings:
                    return new SettingsPage();

                case ApplicationPage.Location:
                    return new LocationPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
