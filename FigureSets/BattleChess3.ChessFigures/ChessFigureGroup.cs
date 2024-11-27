using BattleChess3.ChessFigures.Localization;
using BattleChess3.Game.Figures;

namespace BattleChess3.ChessFigures;

public class ChessFigureGroup : IFigureGroup
{
    public string DisplayName => CurrentLocalization.Instance[$"{nameof(ChessFigureGroup)}_Name"];

    public static readonly IFigureType King = new King();
    public static readonly IFigureType Queen = new Queen();
    public static readonly IFigureType Rook = new Rook();
    public static readonly IFigureType Bishop = new Bishop();
    public static readonly IFigureType Knight = new Knight();
    public static readonly IFigureType Pawn = new Pawn();

    public IFigureType[] FigureTypes =>
        new[]
        {
            King,
            Queen,
            Rook,
            Bishop,
            Knight,
            Pawn
        };
}