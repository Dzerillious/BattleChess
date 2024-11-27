namespace BattleChess3.UI.Themes;

/// <summary>
///     Service for handling themes.
/// </summary>
public interface IThemeService
{
    /// <summary>
    ///     Raised when themes collection changes.
    /// </summary>
    event EventHandler<IList<ThemeModel>>? ThemesChanged;

    /// <summary>
    ///     Gets current themes.
    /// </summary>
    IList<ThemeModel> GetCurrentThemes();
}