using System.Resources;
using System.Windows.Data;
using BattleChess3.Core.Utilities;
using BattleChess3.UI.Localization;

namespace BattleChess3.UI.Utilities
{
    internal class CurrentLocalization : LocalizationSourceBase
    {
        public static LocalizationSourceBase Instance { get; } = new CurrentLocalization();
        private CurrentLocalization()
        {
            Sources.Add(this);
        }

        protected override ResourceManager ResManager() => Strings.ResourceManager;
    }

    internal class LocExtension : Binding
    {
        public LocExtension(string name) : base("[" + name + "]")
        {
            Mode = BindingMode.OneWay;
            Source = CurrentLocalization.Instance;
        }
    }
}