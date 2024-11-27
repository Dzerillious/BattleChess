using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.CrossFireFigures;

public class Spy : ICrossFireFigureType
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