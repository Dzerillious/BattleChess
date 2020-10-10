using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace BattleChess3.Core.Utilities
{
    public abstract class LocalizationSourceBase : INotifyPropertyChanged
    {
        protected static readonly List<LocalizationSourceBase> Sources = new List<LocalizationSourceBase>();
        private static CultureInfo _currentCulture = CultureInfo.CurrentCulture;

        protected abstract ResourceManager ResManager();

        public string this[string key] => ResManager().GetString(key, CultureInfo.CurrentCulture) ?? string.Empty;

        public static CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                _currentCulture = value;
                foreach (LocalizationSourceBase source in Sources)
                    source.PropertyChanged?.Invoke(source, new PropertyChangedEventArgs(string.Empty));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}