using BattleChess3.Game.Figures;
using BattleChess3.SpyFigures.Localization;

namespace BattleChess3.SpyFigures;

public class SpyFigureGroup : IFigureGroup
{
    public string DisplayName => CurrentLocalization.Instance[$"{nameof(SpyFigureGroup)}_Name"];

    public static readonly IFigureType SpyKing = new SpyKing();
    public static readonly IFigureType SpyQueen = new SpyQueen();
    public static readonly IFigureType SpyRook = new SpyRook();
    public static readonly IFigureType SpyBishop = new SpyBishop();
    public static readonly IFigureType SpyKnight = new SpyKnight();
    public static readonly IFigureType SpyPawn = new SpyPawn();

    public IFigureType[] FigureTypes =>
        new[]
        {
            SpyKing,
            SpyQueen,
            SpyRook,
            SpyBishop,
            SpyKnight,
            SpyPawn
        };
}