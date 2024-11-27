using BattleChess3.ExplodingChessFigures.Localization;
using BattleChess3.Game.Figures;

namespace BattleChess3.ExplodingChessFigures;

public class ExplodingChessFigureGroup : IFigureGroup
{
    public string DisplayName => CurrentLocalization.Instance[$"{nameof(ExplodingChessFigureGroup)}_Name"];

    public static readonly IFigureType ExplodingKing = new ExplodingChessKing();
    public static readonly IFigureType ExplodingQueen = new ExplodingChessQueen();
    public static readonly IFigureType ExplodingRook = new ExplodingChessRook();
    public static readonly IFigureType ExplodingBishop = new ExplodingChessBishop();
    public static readonly IFigureType ExplodingKnight = new ExplodingChessKnight();
    public static readonly IFigureType ExplodingPawn = new ExplodingChessPawn();

    public IFigureType[] FigureTypes =>
        new[]
        {
            ExplodingKing,
            ExplodingQueen,
            ExplodingRook,
            ExplodingBishop,
            ExplodingKnight,
            ExplodingPawn
        };
}