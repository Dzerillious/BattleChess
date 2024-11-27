using System.IO;
using System.Windows;

namespace BattleChess3.UI.Themes;

internal class ThemeService : IThemeService
{
    private readonly FileSystemWatcher _watcher;

    private ThemeModel[] _themes = Array.Empty<ThemeModel>();

    public ThemeService()
    {
        _watcher = new FileSystemWatcher(".");

        _watcher.NotifyFilter = NotifyFilters.Attributes
                                | NotifyFilters.CreationTime
                                | NotifyFilters.DirectoryName
                                | NotifyFilters.FileName
                                | NotifyFilters.LastAccess
                                | NotifyFilters.LastWrite
                                | NotifyFilters.Security
                                | NotifyFilters.Size;

        _watcher.Changed += OnChanged;
        _watcher.Created += OnChanged;
        _watcher.Deleted += OnChanged;
        _watcher.Renamed += OnChanged;

        _watcher.Filter = "*Theme.dll";
        _watcher.IncludeSubdirectories = true;
        _watcher.EnableRaisingEvents = true;

        Application.Current.Dispatcher.Invoke(ReloadThemes);
    }

    public event EventHandler<IList<ThemeModel>>? ThemesChanged;

    public IList<ThemeModel> GetCurrentThemes()
    {
        return _themes;
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        Application.Current.Dispatcher.Invoke(ReloadThemes);
    }

    private void ReloadThemes()
    {
        _themes = Directory.GetFiles(".", "*Theme.dll")
            .Select(path => new ThemeModel(Path.GetFullPath(path)))
            .ToArray();
        ThemesChanged?.Invoke(this, _themes);
    }
}