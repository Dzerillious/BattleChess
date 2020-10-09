using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace BattleChess3.UI.Converters
{
    public class IsNullConverter : MarkupExtension, IValueConverter
    {
        public object NullValue { get; set; }
        public object NotNullValue { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(null)) return NullValue;
            return NotNullValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}