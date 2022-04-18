using BattleChess3.UI.Model;
using System;
using System.Collections.Generic;

namespace BattleChess3.UI.Services;

/// <summary>
/// Service for handling themes.
/// </summary>
public interface IThemesService
{
    /// <summary>
    /// Raised when themes collection changes.
    /// </summary>
    event EventHandler<IList<ThemeModel>> ThemesChanged;

    /// <summary>
    /// Gets current themes.
    /// </summary>
    IList<ThemeModel> GetCurrentThemes();
}
