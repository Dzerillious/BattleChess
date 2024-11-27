using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.CrossFireFigures;

public class Ninja : ICrossFireFigureType
{
    private readonly Position[] _attackPositions =
    {
        (-1, 0), (1, 0), (0, -1), (0, 1)
    };

    public IEnumerable<FigureAction> GetPossibleActions(ITile unitTile, IBoard board)
    {
        foreach (var attackPosition in _attackPositions)
        {
            var position = unitTile.Position + attackPosition;
            if (!board.TryGetTile(position, out var targetTile))
                continue;
            
            if (targetTile.IsOwnedByEnemy(unitTile))
            {
                yield return unitTile.CreateKillWithMove(targetTile, board);
            }
        }

        if (TryGetMoveAction(unitTile, board, (-1, 1), out var move1Action))
        {
            yield return move1Action;
        }

        if (TryGetMoveAction(unitTile, board, (1, 1), out var move2Action))
        {
            yield return move2Action;
        }

        if (board.TryGetTile(unitTile.Position + (0, 1), out var tileBefore) &&
            !tileBefore.IsEmpty() &&
            TryGetMoveAction(unitTile, board, (0, 2), out var move3Action))
        {
            yield return move3Action;
        }
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

        action = unitTile.CreateMoveAction(targetTile, board);
        return true;
    }
}