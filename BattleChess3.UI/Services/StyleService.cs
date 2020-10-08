using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using Style = BattleChess3.Core.Models.Style;

namespace BattleChess3.UI.Services
{
    public class StyleService : ViewModelBase
    {
        private static readonly ImageSourceConverter ImageSourceConverter = new ImageSourceConverter();
        
        private Style _selectedStyle;
        public Style SelectedStyle
        {
            get => _selectedStyle;
            set
            {
                Set(ref _selectedStyle, value);

                foreach (string file in Directory.GetFiles(value.Directory))
                {
                    string key = Path.GetFileNameWithoutExtension(Path.GetFileName(file));
                    ImageSource imageSource = (ImageSource) ImageSourceConverter.ConvertFromString(file);
                    Application.Current.Resources[key] = imageSource;
                    Application.Current.Resources[$"{key}Brush"] = new ImageBrush(imageSource);
                }
            }
        }

        private Style[] _styles;
        public Style[] Styles
        {
            get => _styles;
            set => Set(ref _styles, value);
        }

        public StyleService()
        {
            ReloadStyles();
        }

        public void ReloadStyles()
        {
            string directory = Path.GetFullPath("Resources\\Styles");
            Styles = Directory.GetDirectories(directory)
                              .Select(dir => new Style(dir))
                              .ToArray();
            SelectedStyle = Styles.FirstOrDefault(style => style.Directory.Contains("Paper"))
                         ?? Styles.First();
        }
    }
}