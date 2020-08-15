using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Data;
using BattleChess3.Core.Figures;
using BattleChess3.Core.Models;
using BattleChess3.Core.Utilities;
using Newtonsoft.Json;

namespace BattleChess3.UI.Converters
{
    public class FigurePicturePathsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is IFigureType figureType)) return Array.Empty<string>();
            DirectoryInfo directory = new DirectoryInfo($"FigureSets/{figureType.GroupName}");
            var items = directory.GetFiles($"{figureType.UnitName}*")
                .Select(file => file.FullName)
                .ToArray();
            return items;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}