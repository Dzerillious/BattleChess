using System;
using System.IO;
using System.Linq;
using System.Windows;
using BattleChess3.UI.ViewModel;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.Services;

public class ThemeService : ViewModelBase
{
    private ThemeViewModel _selectedTheme = ThemeViewModel.None;

    private ThemeViewModel[] _themes = Array.Empty<ThemeViewModel>();

    public ThemeService()
    {
        ReloadStyles();
    }

    public ThemeViewModel SelectedTheme
    {
        get => _selectedTheme;
        set
        {
            Set(ref _selectedTheme, value);
            foreach (var keyObject in value.ResourceDictionary.Keys)
            {
                if (!(keyObject is { } key)) return;
                Application.Current.Resources[key] = value.ResourceDictionary[key];
            }
        }
    }

    public ThemeViewModel[] Themes
    {
        get => _themes;
        set => Set(ref _themes, value);
    }

    public void ReloadStyles()
    {
        Themes = Directory.GetFiles(".", "*Theme.dll")
            .Select(path => new ThemeViewModel(Path.GetFullPath(path)))
            .ToArray();
        SelectedTheme = Themes.FirstOrDefault(style => style.Name.Contains("Paper"))
                        ?? Themes.First();
    }
}
