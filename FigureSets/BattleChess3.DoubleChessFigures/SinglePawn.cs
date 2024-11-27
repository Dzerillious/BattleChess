using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.DoubleChessFigures;

public class SinglePawn : IDoubleChessFigureType
{
    private IDoubleChessFigureType DoubleChessFigureType => this;
    
    public IEnumerable<FigureAction> GetPossibleActions(ITile unitTile, IBoard board)
    {
        if (TryGetAttackAction(unitTile, board, (1, 1), out var attackAction1))
        {
            yield return attackAction1;
        }

        if (TryGetAttackAction(unitTile, board, (-1, 1), out var attackAction2))
        {
            yield return attackAction2;
        }

        if (TryGetMoveAction(unitTile, board, (0, 1), out var moveAction1))
        {
            yield return moveAction1;
        }
        else if (TryGetMergeAction(unitTile, board, (0, 1), out var mergeAction1))
        {
            yield return mergeAction1;
            yield break;
        }
        else
        {
            yield break;
        }

        if (unitTile.Position.Y != 1)
        {
            yield break;
        }
        
        if (TryGetMoveAction(unitTile, board, (0, 2), out var moveAction2))
        {
            yield return moveAction2;
        }
        else if (TryGetMergeAction(unitTile, board, (0, 2), out var mergeAction2))
        {
            yield return mergeAction2;
        }
    }

    private static bool TryGetAttackAction(ITile unitTile, IBoard board, Position relativePosition, out FigureAction action)
    {
        var attackPosition = unitTile.Position + relativePosition;
        if (!board.TryGetTile(attackPosition, out var targetTile) ||
            !targetTile.IsOwnedByEnemy(unitTile))
        {
            action = FigureAction.None;
            return false;
        }

        if (attackPosition.Y == 7)
        {
            action = new FigureAction(
                FigureActionTypes.Special,
                unitTile.AbsolutePosition,
                targetTile.AbsolutePosition,
                () =>
                {
                    unitTile.KillWithoutMove(targetTile, board);
                    targetTile.CreateFigure(new Figure(unitTile.Figure.Owner, DoubleChessFigureGroup.Queen), board);
                    unitTile.Die(board);
                });
        }
        else
        {
            action = unitTile.CreateKillWithMove(targetTile, board);
        }
        
        return true;
    }

    private static bool TryGetMoveAction(ITile unitTile, IBoard board, Position relativePosition, out FigureAction action)
    {
        var movePosition = unitTile.Position + relativePosition;
        if (!board.TryGetTile(movePosition, out var targetTile) ||
            !targetTile.IsEmpty())
        {
            action = FigureAction.None;
            return false;
        }

        if (movePosition.Y == 7)
        {
            action = new FigureAction(
                FigureActionTypes.Special,
                unitTile.AbsolutePosition,
                targetTile.AbsolutePosition,
                () =>
                {
                    targetTile.CreateFigure(new Figure(unitTile.Figure.Owner, DoubleChessFigureGroup.Queen), board);
                    unitTile.Die(board);
                });
        }
        else
        {
            action = unitTile.CreateMoveAction(targetTile, board);
        }
        
        return true;
    }

    private bool TryGetMergeAction(ITile unitTile, IBoard board, Position relativePosition, out FigureAction action)
    {
        var mergePosition = unitTile.Position + relativePosition;
        if (!board.TryGetTile(mergePosition, out var targetTile) ||
            !targetTile.IsOwnedByYou(unitTile))
        {
            action = FigureAction.None;
            return false;
        }

        if (mergePosition.Y == 7)
        {
            action = new FigureAction(
                FigureActionTypes.Special,
                unitTile.AbsolutePosition,
                targetTile.AbsolutePosition,
                () =>
                {
                    var owner = unitTile.Figure.Owner;
                    unitTile.Die(board);
                    unitTile.CreateFigure(new Figure(owner, DoubleChessFigureGroup.Queen), board);
                    if (DoubleChessFigureType.TryCreateMergeAction(unitTile, targetTile, board, out var mergeAction))
                    {
                        mergeAction.Action.Invoke();
                    }
                });
            return true;
        }

        return DoubleChessFigureType.TryCreateMergeAction(unitTile, targetTile, board, out action);
    }
}