using System;
using System.Globalization;
using System.Windows.Data;

namespace Bar
{
    class ConvertToMeterOpacity : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value >= Int32.Parse((string)parameter) ? 1.0 : 0.3;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
