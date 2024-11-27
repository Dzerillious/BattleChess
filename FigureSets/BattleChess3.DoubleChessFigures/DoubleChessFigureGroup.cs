using BattleChess3.DoubleChessFigures.Localization;
using BattleChess3.Game.Figures;

namespace BattleChess3.DoubleChessFigures;

public class DoubleChessFigureGroup : IFigureGroup
{
    public static readonly IFigureType King =
        new SingleKing();

    public static readonly IFigureType KingQueen =
        new CombinedChessFigureType<SingleKing, SingleQueen>(nameof(KingQueen));
    
    public static readonly IFigureType KingRook =
        new CombinedChessFigureType<SingleKing, SingleRook>(nameof(KingRook));

    public static readonly IFigureType KingKnight =
        new CombinedChessFigureType<SingleKing, SingleKnight>(nameof(KingKnight));

    public static readonly IFigureType KingBishop =
        new CombinedChessFigureType<SingleKing, SingleBishop>(nameof(KingBishop));

    public static readonly IFigureType KingPawn =
        new CombinedChessFigureType<SingleKing, SinglePawn>(nameof(KingPawn));

    public static readonly IFigureType Queen =
        new SingleQueen();

    public static readonly IFigureType QueenQueen =
        new CombinedChessFigureType<SingleQueen, SingleQueen>(nameof(QueenQueen));

    public static readonly IFigureType QueenRook =
        new CombinedChessFigureType<SingleQueen, SingleRook>(nameof(QueenRook));

    public static readonly IFigureType QueenKnight =
        new CombinedChessFigureType<SingleQueen, SingleKnight>(nameof(QueenKnight));

    public static readonly IFigureType QueenBishop =
        new CombinedChessFigureType<SingleQueen, SingleBishop>(nameof(QueenBishop));

    public static readonly IFigureType QueenPawn =
        new CombinedChessFigureType<SingleQueen, SinglePawn>(nameof(QueenPawn));

    public static readonly IFigureType Rook =
        new SingleRook();

    public static readonly IFigureType RookRook =
        new CombinedChessFigureType<SingleRook, SingleRook>(nameof(RookRook));

    public static readonly IFigureType RookKnight =
        new CombinedChessFigureType<SingleRook, SingleKnight>(nameof(RookKnight));

    public static readonly IFigureType RookBishop =
        new CombinedChessFigureType<SingleRook, SingleBishop>(nameof(RookBishop));

    public static readonly IFigureType RookPawn =
        new CombinedChessFigureType<SingleRook, SinglePawn>(nameof(RookPawn));

    public static readonly IFigureType Knight =
        new SingleKnight();

    public static readonly IFigureType KnightKnight =
        new CombinedChessFigureType<SingleKnight, SingleKnight>(nameof(KnightKnight));

    public static readonly IFigureType KnightBishop =
        new CombinedChessFigureType<SingleKnight, SingleBishop>(nameof(KnightBishop));

    public static readonly IFigureType KnightPawn =
        new CombinedChessFigureType<SingleKnight, SinglePawn>(nameof(KnightPawn));

    public static readonly IFigureType Bishop =
        new SingleBishop();

    public static readonly IFigureType BishopBishop =
        new CombinedChessFigureType<SingleBishop, SingleBishop>(nameof(BishopBishop));

    public static readonly IFigureType BishopPawn =
        new CombinedChessFigureType<SingleBishop, SinglePawn>(nameof(BishopPawn));

    public static readonly IFigureType Pawn =
        new SinglePawn();

    public static readonly IFigureType PawnPawn =
        new CombinedChessFigureType<SinglePawn, SinglePawn>(nameof(PawnPawn));

    public string DisplayName => CurrentLocalization.Instance[$"{nameof(DoubleChessFigureGroup)}_Name"];

    public IFigureType[] FigureTypes =>
        new[]
        {
            King, KingQueen, KingRook, KingKnight, KingBishop, KingPawn,
            Queen, QueenQueen, QueenRook, QueenKnight, QueenBishop, QueenPawn,
            Rook, RookRook, RookKnight, RookBishop, RookPawn,
            Knight, KnightKnight, KnightBishop, KnightPawn,
            Bishop, BishopBishop, BishopPawn,
            Pawn, PawnPawn
        };
}