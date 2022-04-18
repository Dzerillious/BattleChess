using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using BattleChess3.UI.Model;
using BattleChess3.UI.Services;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel;

public class ThemesViewModel : ViewModelBase
{
    public readonly IThemesService _themesService;

    private ThemeModel _selectedTheme = ThemeModel.None;
    public ThemeModel SelectedTheme
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

    private IList<ThemeModel> _themes = Array.Empty<ThemeModel>();
    public IList<ThemeModel> Themes
    {
        get => _themes;
        set
        {
            Set(ref _themes, value);
            if (!_themes.Contains(_selectedTheme))
            {
                SelectedTheme = _themes.FirstOrDefault(x => x.Name.Contains("Paper")) ??
                    _themes.FirstOrDefault() ??
                    ThemeModel.None;
            }
        }
    }

    public ThemesViewModel(
        IThemesService themesService)
    {
        _themesService = themesService;
        Themes = _themesService.GetCurrentThemes();
        _themesService.ThemesChanged += OnThemesChanged;
    }

    private void OnThemesChanged(object? sender, IList<ThemeModel> themes)
    {
        Themes = themes;
    }
}
