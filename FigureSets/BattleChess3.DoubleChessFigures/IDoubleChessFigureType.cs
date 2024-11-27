using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.DoubleChessFigures.Localization;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.DoubleChessFigures;

internal interface IDoubleChessFigureType : IFigureType
{
    string IFigureType.UnitName => $"{nameof(DoubleChessFigureGroup)}.{GetType().Name}";
    string IFigureType.DisplayName => CurrentLocalization.Instance[$"{GetType().Name}_Name"];
    string IFigureType.Description => CurrentLocalization.Instance[$"{GetType().Name}_{nameof(Description)}"];

    IDictionary<int, Uri> IFigureType.ImageUris =>
        new Dictionary<int, Uri>
        {
            { 1, new Uri($"pack://application:,,,/BattleChess3.DoubleChessFigures;component/Images/{GetType().Name}1.png", UriKind.Absolute) },
            { 2, new Uri($"pack://application:,,,/BattleChess3.DoubleChessFigures;component/Images/{GetType().Name}2.png", UriKind.Absolute) }
        };

    bool TryCreateMergeAction(ITile tile1, ITile tile2, IBoard board, out FigureAction action)
    {
        var figure1 = this;
        var figure2 = tile2.Figure.Type;
        
        action = figure1 switch
        {
            SinglePawn when figure2 is SinglePawn => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.PawnPawn, board),
            SinglePawn when figure2 is SingleBishop => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.BishopPawn, board),
            SingleBishop when figure2 is SinglePawn => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.BishopPawn, board),
            SinglePawn when figure2 is SingleKnight => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KnightPawn, board),
            SingleKnight when figure2 is SinglePawn => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KnightPawn, board),
            SinglePawn when figure2 is SingleRook => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.RookPawn, board),
            SingleRook when figure2 is SinglePawn => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.RookPawn, board),
            SinglePawn when figure2 is SingleQueen => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.QueenPawn, board),
            SingleQueen when figure2 is SinglePawn => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.QueenPawn, board),
            SinglePawn when figure2 is SingleKing => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KingPawn, board),
            SingleKing when figure2 is SinglePawn => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KingPawn, board),
            SingleBishop when figure2 is SingleBishop => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.BishopBishop, board),
            SingleBishop when figure2 is SingleKnight => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KnightBishop, board),
            SingleKnight when figure2 is SingleBishop => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KnightBishop, board),
            SingleBishop when figure2 is SingleRook => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.RookBishop, board),
            SingleRook when figure2 is SingleBishop => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.RookBishop, board),
            SingleBishop when figure2 is SingleQueen => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.QueenBishop, board),
            SingleQueen when figure2 is SingleBishop => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.QueenBishop, board),
            SingleBishop when figure2 is SingleKing => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KingBishop, board),
            SingleKing when figure2 is SingleBishop => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KingBishop, board),
            SingleKnight when figure2 is SingleKnight => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KnightKnight, board),
            SingleKnight when figure2 is SingleRook => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.RookKnight, board),
            SingleRook when figure2 is SingleKnight => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.RookKnight, board),
            SingleKnight when figure2 is SingleQueen => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.QueenKnight, board),
            SingleQueen when figure2 is SingleKnight => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.QueenKnight, board),
            SingleKnight when figure2 is SingleKing => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KingKnight, board),
            SingleKing when figure2 is SingleKnight => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KingKnight, board),
            SingleRook when figure2 is SingleRook => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.RookRook, board),
            SingleRook when figure2 is SingleQueen => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.QueenRook, board),
            SingleQueen when figure2 is SingleRook => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.QueenRook, board),
            SingleRook when figure2 is SingleKing => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KingRook, board),
            SingleKing when figure2 is SingleRook => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KingRook, board),
            SingleQueen when figure2 is SingleQueen => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.QueenQueen, board),
            SingleQueen when figure2 is SingleKing => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KingQueen, board),
            SingleKing when figure2 is SingleQueen => TryCreateMergeAction(tile1, tile2, DoubleChessFigureGroup.KingQueen, board),
            _ => FigureAction.None
        };
        
        return action != FigureAction.None;
    }

    FigureAction TryCreateMergeAction(ITile tile1, ITile tile2, IFigureType figureType, IBoard board)
    {
        return new FigureAction(
            FigureActionTypes.Special,
            tile1.AbsolutePosition,
            tile2.AbsolutePosition,
            () =>
            {
                tile2.Die(board);
                tile2.CreateFigure(new Figure(tile1.Figure.Owner, figureType), board);
                tile1.Die(board);
            });
    }
}