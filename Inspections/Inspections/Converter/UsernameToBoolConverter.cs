using Inspections.Behaviors;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Inspections.Converter
{
    class UsernameToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.ToString().Length > 0 && EmailBehavior.IsValidEmail((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
