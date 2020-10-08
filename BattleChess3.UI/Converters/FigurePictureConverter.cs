using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Data;
using BattleChess3.Core.Models;

namespace BattleChess3.UI.Converters
{
    public class FigurePictureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Figure figure)) return string.Empty;
            DirectoryInfo directory = new DirectoryInfo($"FigureSets/{figure.FigureType.GroupName}");
            string picture = directory.GetFiles($"{figure.FigureType.UnitName}{figure.Owner.Id}*")
                                      .Select(file => file.FullName)
                                      .First();
            return picture;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}