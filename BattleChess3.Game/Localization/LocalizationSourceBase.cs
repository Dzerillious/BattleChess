using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace BattleChess3.Game.Localization;

public abstract class LocalizationSourceBase : INotifyPropertyChanged
{
    protected static readonly List<LocalizationSourceBase> Sources = new();
    private static CultureInfo _currentCulture = CultureInfo.CurrentCulture;

    public string this[string key] => ResManager().GetString(key, CultureInfo.CurrentCulture) ?? string.Empty;

    public static CultureInfo CurrentCulture
    {
        get => _currentCulture;
        set
        {
            _currentCulture = value;
            foreach (var source in Sources)
            {
                source.PropertyChanged?.Invoke(source, new PropertyChangedEventArgs(string.Empty));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected abstract ResourceManager ResManager();
}