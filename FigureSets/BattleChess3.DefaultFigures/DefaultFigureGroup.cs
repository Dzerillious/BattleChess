using BattleChess3.DefaultFigures.Localization;
using BattleChess3.Game.Figures;

namespace BattleChess3.DefaultFigures;

public class DefaultFigureGroup : IFigureGroup
{
    public string DisplayName => CurrentLocalization.Instance[$"{nameof(DefaultFigureGroup)}_Name"];

    public static readonly IFigureType Palm = new Palm();
    public static readonly IFigureType Empty = new Empty();
    public static readonly IFigureType Stone = new Stone();
    public static readonly IFigureType Water = new Water();
    
    public IFigureType[] FigureTypes =>
        new[]
        {
            Palm,
            Empty,
            Stone,
            Water
        };
}