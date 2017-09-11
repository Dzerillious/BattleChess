using System;
using System.Globalization;
using System.Windows.Data;

namespace BattleChess3
{
    public class IsEmptyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value == "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("IsEmptyStringConverter can only be used OneWay.");
        }
    }
}