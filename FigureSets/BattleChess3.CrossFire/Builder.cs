using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.CrossFireFigures;

public class Builder : ICrossFireFigureType
{
    private readonly Position[] _movePosition =
    {
        (-1, 0), (1, 0), (0, -1), (0, 1)
    };
    
    private readonly Position[] _shieldPositions =
    {
        (-2, 1), (-2, 0), (-2, -1),
        (2, 1), (2, 0), (2, -1),
        (1, -2), (0, -2), (-1, -2),
        (1, 2), (0, 2), (-1, 2)
    };
    
    public IEnumerable<FigureAction> GetPossibleActions(ITile unitTile, IBoard board)
    {
        foreach (var movement in _movePosition)
        {
            var position = unitTile.Position + movement;
            if (!board.TryGetTile(position, out var targetTile))
                continue;
            
            if (targetTile.IsEmpty())
            {
                yield return new FigureAction(
                    FigureActionTypes.Move, 
                    unitTile.AbsolutePosition,
                    targetTile.AbsolutePosition,
                    () =>
                    {
                        MoveFiguresOutsideShield(unitTile, movement, board);
                        MoveShield(unitTile, movement, board);
                        unitTile.MoveToTile(targetTile, board);
                    });
            }
        }
    }

    private void MoveShield(ITile sourceTile, Position move, IBoard board)
    {
        foreach (var shieldPosition in _shieldPositions)
        {
            if (!(sourceTile.Position + shieldPosition).IsInBoard())
            {
                continue;
            }

            var shieldTile = board[sourceTile.Position + shieldPosition];
            if (shieldTile.Figure.Type is Wall &&
                shieldTile.Figure.Owner.Equals(sourceTile.Figure.Owner))
            {
                shieldTile.Die(board);
            }
        }

        foreach (var shieldPosition in _shieldPositions)
        {
            if (!(sourceTile.Position + shieldPosition + move).IsInBoard())
            {
                continue;
            }

            var shieldTile = board[sourceTile.Position + shieldPosition + move];
            if (shieldTile.IsEmpty())
            {
                shieldTile.CreateFigure(new Figure(sourceTile.Figure.Owner, CrossFireFigureGroup.Wall), board);
            }
        }
    }

    private static void MoveFiguresOutsideShield(ITile sourceTile, Position move, IBoard board)
    {
        var movedPositions = GetMovedPositions(move);
        foreach (var movedPosition in movedPositions)
        {
            if (!(sourceTile.Position + movedPosition).IsInBoard())
            {
                continue;
            }

            var movedTile = board[sourceTile.Position + movedPosition];
            if (movedTile.IsEmpty() ||
                movedTile.Figure.Type is Wall)
            {
                continue;
            }

            if (!(sourceTile.Position + movedPosition + move).IsInBoard())
            {
                movedTile.Die(board);
                continue;
            }

            var moveTargetTile = board[sourceTile.Position + movedPosition + move];
            if (moveTargetTile.IsEmpty())
            {
                movedTile.MoveToTile(moveTargetTile, board);
            }
            else
            {
                movedTile.KillWithMove(moveTargetTile, board);
            }
        }
    }

    private static IEnumerable<Position> GetMovedPositions(Position move)
    {
        return move switch
        {
            (0, 1) => new Position[] { (-2, 2), (-1, 3), (0, 3), (1, 3), (2, 2) },
            (1, 0) => new Position[] { (2, -2), (3, -1), (3, 0), (3, 1), (2, 2) },
            (0, -1) => new Position[] { (-2, -2), (-1, -3), (0, -3), (1, -3), (2, -2) },
            (-1, 0) => new Position[] { (-2, -2), (-3, -1), (-3, 0), (-3, 1), (-2, 2) },
            _ => throw new ArgumentException($"Unexpected move of Builder {move}")
        };
    }
}