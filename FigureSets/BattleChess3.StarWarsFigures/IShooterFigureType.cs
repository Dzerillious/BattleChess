using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.StarWarsFigures;

internal interface IShooterFigureType : IFigureType
{
    protected Position[] AttackDirections => new Position[]
    {
        (-1, -1), (-1, 1),
        (1, -1), (1, 1)
    };

    protected Position[] MovePositions => new Position[]
    {
        (-1, 0), (0, -1), (0, 1), (1, 0)
    };
    
    IEnumerable<FigureAction> IFigureType.GetPossibleActions(ITile unitTile, IBoard board)
    {
        foreach (var direction in AttackDirections)
        {
            for (var i = 1; i <= 3; i++)
            {
                var position = unitTile.Position + direction * i;
                if (!board.TryGetTile(position, out var targetTile))
                    break;
                
                if (targetTile.IsOwnedByEnemy(unitTile))
                {
                    yield return unitTile.CreateKillWithoutMove(targetTile, board);
                }
                
                if (targetTile.IsEmpty())
                {
                    yield return unitTile.CreateMoveAction(targetTile, board);
                }
                else if (targetTile.Figure.Type is Bomb &&
                         targetTile.IsOwnedByYou(unitTile))
                {
                    yield return unitTile.CreateKillWithoutMove(targetTile, board);
                    break;
                }
                else
                {
                    break;
                }
            }
        }
        
        foreach (var movement in MovePositions)
        {
            var position = unitTile.Position + movement;
            if (!board.TryGetTile(position, out var targetTile))
                continue;
            
            if (targetTile.IsEmpty())
            {
                yield return unitTile.CreateMoveAction(targetTile, board);
            }
            else if (targetTile.Figure.Type is Bomb &&
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
    }
}