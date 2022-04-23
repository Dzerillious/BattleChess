using System.Resources;
using BattleChess3.Core.Utilities;

namespace BattleChess3.CrossFireFigures.Localization
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
}