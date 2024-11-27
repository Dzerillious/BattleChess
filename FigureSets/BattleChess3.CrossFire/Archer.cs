using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.CrossFireFigures;

public class Archer : ICrossFireFigureType
{
    private readonly Position[] _directions = 
    {
        (-1, -1), (-1, 1),
        (0, -1), (0, 1),
        (1, -1), (1, 1)
    };

    IEnumerable<FigureAction> IFigureType.GetPossibleActions(ITile unitTile, IBoard board)
    {
        foreach (var direction in _directions)
        {
            for (var i = 1; i < 8; i++)
            {
                var position = unitTile.Position + direction * i;
                if (!board.TryGetTile(position, out var targetTile))
                    break;
                
                if (targetTile.IsOwnedByEnemy(unitTile))
                {
                    yield return unitTile.CreateKillWithMove(targetTile, board);
                }

                if (!targetTile.IsEmpty())
                {
                    break;
                }
            }
        }
        
        if (TryGetMoveAction(unitTile, board, (-1, 0), out var move1Action))
        {
            yield return move1Action;
        }
        
        if (TryGetMoveAction(unitTile, board, (1, 0), out var move2Action))
        {
            yield return move2Action;
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