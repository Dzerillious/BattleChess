using System.Resources;
using BattleChess3.Game.Localization;

namespace BattleChess3.DefaultFigures.Localization;

internal class CurrentLocalization : LocalizationSourceBase
{
    private CurrentLocalization()
    {
        Sources.Add(this);
    }

    public static LocalizationSourceBase Instance { get; } = new CurrentLocalization();

    protected override ResourceManager ResManager()
    {
        return Strings.ResourceManager;
    }
}