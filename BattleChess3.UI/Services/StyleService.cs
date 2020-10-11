using System;
using System.IO;
using System.Linq;
using System.Windows;
using BattleChess3.UI.ViewModel;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.Services
{
    public class StyleService : ViewModelBase
    {
        private StyleViewModel _selectedStyle = StyleViewModel.Invalid;
        public StyleViewModel SelectedStyle
        {
            get => _selectedStyle;
            set
            {
                Set(ref _selectedStyle, value);
                foreach (object? keyObject in value.ResourceDictionary.Keys)
                {
                    if (!(keyObject is { } key)) return;
                    Application.Current.Resources[key] = value.ResourceDictionary[key];
                }
            }
        }

        private StyleViewModel[] _styles = Array.Empty<StyleViewModel>();
        public StyleViewModel[] Styles
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
                              .Select(fileInfo => new StyleViewModel(fileInfo.FullName))
                              .ToArray();
            SelectedStyle = Styles.FirstOrDefault(style => style.Name.Contains("Paper"))
                         ?? Styles.First();
        }
    }
}