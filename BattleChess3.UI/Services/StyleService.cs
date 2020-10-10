using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BattleChess3.UI.ViewModel;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.Services
{
    public class StyleService : ViewModelBase
    {
        private StyleViewModel _selectedStyleViewModel = StyleViewModel.Invalid;
        public StyleViewModel SelectedStyleViewModel
        {
            get => _selectedStyleViewModel;
            set
            {
                Set(ref _selectedStyleViewModel, value);
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
            Task.Run(ReloadStyles);
        }
        
        public void ReloadStyles()
        {
            DirectoryInfo directory = new DirectoryInfo("Themes");
            Styles = directory.GetFiles("*.dll")
                              .Select(fileInfo => new StyleViewModel(fileInfo.FullName))
                              .ToArray();
            SelectedStyleViewModel = Styles.FirstOrDefault(style => style.Name.Contains("Paper"))
                                  ?? Styles.First();
        }
    }
}