using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.StarWarsFigures;

internal interface IJediFigureType : IFigureType
{
    Position[] MovementPositions => new Position[]
    {
        (-2, -2), (-2, 0), (-2, 1),
        (0, -2), (0, 2),
        (2, -2), (2, 0), (2, 2)
    };

    Position[] AttackPositions => new Position[]
    {
        (-2, -2), (-2, 2),
        (2, -2), (2, 2)
    };

    IEnumerable<FigureAction> IFigureType.GetPossibleActions(ITile unitTile, IBoard board)
    {
        foreach (var movementPosition in MovementPositions)
        {
            var position = unitTile.Position + movementPosition;
            if (!board.TryGetTile(position, out var targetTile))
                continue;
            
            if (targetTile.IsEmpty())
            {
                yield return unitTile.CreateMoveAction(targetTile, board);
            }

            if (targetTile.Figure.Type is Bomb &&
                targetTile.IsOwnedByYou(unitTile))
            {
                yield return new FigureAction(
                    FigureActionTypes.Move,
                    unitTile.AbsolutePosition,
                    targetTile.AbsolutePosition,
                    () =>
                    {
                        targetTile.Die(board);
                        unitTile.MoveToTile(targetTile, board);
                    });
            }
        }

        foreach (var attackPosition in AttackPositions)
        {
            var position = unitTile.Position + attackPosition;
            if (!board.TryGetTile(position, out var targetTile))
                continue;
            
            if (targetTile.IsOwnedByEnemy(unitTile))
            {
                yield return unitTile.CreateKillWithMove(targetTile, board);
            }

            if (targetTile.Figure.Type is Bomb &&
                targetTile.IsOwnedByYou(unitTile))
            {
                yield return unitTile.CreateKillWithMove(targetTile, board);
            }
        }
    }

    void IFigureType.OnMoved(ITile unitTile, ITile targetTile, IBoard board)
    {
        var movement = targetTile.Position - unitTile.Position;
        if (Math.Abs(movement.X) == Math.Abs(movement.Y))
        {
            TryDestroyTile(targetTile, board, (1, 0));
            TryDestroyTile(targetTile, board, (-1, 0));
            TryDestroyTile(targetTile, board, (0, 1));
            TryDestroyTile(targetTile, board, (0, -1));
        }
        else
        {
            TryDestroyTile(targetTile, board, (1, -1));
            TryDestroyTile(targetTile, board, (-1, 1));
            TryDestroyTile(targetTile, board, (1, 1));
            TryDestroyTile(targetTile, board, (-1, -1));
        }
    }

    private static void TryDestroyTile(ITile unitTile, IBoard board, Position positionDiff)
    {
        if (!board.TryGetTile(unitTile.Position + positionDiff, out var targetTile))
            return;

        if (!targetTile.IsEmpty() &&
            !unitTile.Figure.Owner.Equals(targetTile.Figure.Owner))
        {
            unitTile.KillWithoutMove(targetTile, board);
        }
    }
}