using System.Resources;
using BattleChess3.Core.Resources;

namespace BattleChess3.Core.Utilities
{
    internal class CurrentLocalization : LocalizationSourceBase
    {
        public static LocalizationSourceBase Instance { get; } = new CurrentLocalization();
        private CurrentLocalization()
        {
            Sources.Add(this);
        }

        protected override ResourceManager ResManager() => Strings.ResourceManager;
        public static string GetString(string key) => Instance[key];
    }
}