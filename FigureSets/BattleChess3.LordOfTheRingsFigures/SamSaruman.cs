using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.LordOfTheRingsFigures;

public class SamSaruman : ILordOfTheRingsFigureType
{
    private readonly Position[] _movePositions =
    {
        (-1, 0), (1, 0), (0, -1), (0, 1)
    };

    private readonly Position[] _attackDirections =
    {
        (-1, -1), (-1, 1), (1, -1), (1, 1)
    };

    IEnumerable<FigureAction> IFigureType.GetPossibleActions(ITile unitTile, IBoard board)
    {
        foreach (var movement in _movePositions)
        {
            var position = unitTile.Position + movement;
            if (!board.TryGetTile(position, out var targetTile))
                continue;
            
            if (targetTile.IsEmpty())
            {
                yield return unitTile.CreateMoveAction(targetTile, board);
            }
        }
        
        foreach (var direction in _attackDirections)
        {
            for (var i = 1; i <= 2; i++)
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
        
        foreach (var targetTile in board)
        {
            if (targetTile.IsOwnedByYou(unitTile) &&
                targetTile.Figure != unitTile.Figure)
            {
                yield return new FigureAction(
                    FigureActionTypes.Special,
                    unitTile.AbsolutePosition,
                    targetTile.AbsolutePosition,
                    () => unitTile.MoveToTile(targetTile, board));
            }
        }
    }
}