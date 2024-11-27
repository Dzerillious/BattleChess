using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.ExplodingChessFigures;

public class ExplodingChessKing : IExplodingChessFigureType
{
    private readonly Position[] _attackMovePositions = 
    {
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1), (0, 1),
        (1, -1), (1, 0), (1, 1)
    };
    
    public IEnumerable<FigureAction> GetPossibleActions(ITile unitTile, IBoard board)
    {
        foreach (var movement in _attackMovePositions)
        {
            var position = unitTile.Position + movement;
            if (!board.TryGetTile(position, out var targetTile))
                continue;
            
            if (targetTile.IsEmpty())
            {
                yield return unitTile.CreateMoveAction(targetTile, board);
            }

            if (targetTile.IsOwnedByEnemy(unitTile))
            {
                yield return unitTile.CreateKillWithMove(targetTile, board);
            }
        }

        if (unitTile.Position.Y != 0 ||
            unitTile.AbsolutePosition.X != 4)
        {
            yield break;
        }
        
        var rook1Tile = board[0, 0];
        if (rook1Tile.Figure.Type.Equals(ExplodingChessFigureGroup.ExplodingRook) &&
            board[1, 0].IsEmpty() &&
            board[2, 0].IsEmpty() &&
            board[3, 0].IsEmpty())
        {
            yield return new FigureAction(
                FigureActionTypes.Special, 
                unitTile.AbsolutePosition,
                board[2, 0].AbsolutePosition,
                () =>
                {
                    unitTile.MoveToTile(board[2, 0], board);
                    rook1Tile.MoveToTile(board[3, 0], board);
                });
        }

        var rook2Tile = board[7, 0];
        if (rook2Tile.Figure.Type.Equals(ExplodingChessFigureGroup.ExplodingRook) &&
            board[5, 0].IsEmpty() &&
            board[6, 0].IsEmpty())
        {
            yield return new FigureAction(
                FigureActionTypes.Special,
                unitTile.AbsolutePosition,
                board[6, 0].AbsolutePosition,
                () =>
                {
                    unitTile.MoveToTile(board[6, 0], board);
                    rook2Tile.MoveToTile(board[5, 0], board);
                });
        }
    }
}