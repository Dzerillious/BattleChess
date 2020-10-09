using System.IO;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using Style = BattleChess3.UI.ViewModel.Style;

namespace BattleChess3.UI.Services
{
    public class StyleService : ViewModelBase
    {
        private Style _selectedStyle;
        public Style SelectedStyle
        {
            get => _selectedStyle;
            set
            {
                Set(ref _selectedStyle, value);
                foreach (object key in value.ResourceDictionary.Keys)
                    Application.Current.Resources[key] = value.ResourceDictionary[key];
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
            DirectoryInfo directory = new DirectoryInfo("Themes");
            Styles = directory.GetFiles("*.dll")
                              .Select(fileInfo => new Style(fileInfo.FullName))
                              .ToArray();
            SelectedStyle = Styles.FirstOrDefault(style => style.Name.Contains("Paper"))
                         ?? Styles.First();
        }
    }
}