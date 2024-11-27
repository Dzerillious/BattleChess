using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.CrossFireFigures;

public class Knight : ICrossFireFigureType
{
    private readonly Position[] _movePositions = 
    {
        (-2, -1), (-2, 1),
        (-1, -2), (-1, 2),
        (1, -2), (1, 2),
        (2, -1), (2, 1)
    };

    private readonly Position[] _attackPositions =
    {
        (-3, -3), (-2, -2), (-1, -1),
        (-3, 0), (-2, 0), (-1, 0),
        (-3, 3), (-2, 2), (-1, 1),
        (0, -3), (0, -2), (0, -1),
        (0, 3), (0, 2), (0, 1),
        (3, -3), (2, -2), (1, -1),
        (3, 0), (2, 0), (1, 0),
        (3, 3), (2, 2), (1, 1),
    };

    public IEnumerable<FigureAction> GetPossibleActions(ITile unitTile, IBoard board)
    {
        foreach (var movementPosition in _movePositions)
        {
            var position = unitTile.Position + movementPosition;
            if (!board.TryGetTile(position, out var targetTile))
                continue;
            
            if (targetTile.IsEmpty())
            {
                yield return unitTile.CreateMoveAction(targetTile, board);
            }
        }

        foreach (var attackPosition in _attackPositions)
        {
            var position = unitTile.Position + attackPosition;
            if (!board.TryGetTile(position, out var targetTile))
                continue;
            
            if (targetTile.IsOwnedByEnemy(unitTile))
            {
                yield return new FigureAction(
                    FigureActionTypes.Attack, 
                    unitTile.AbsolutePosition,
                    targetTile.AbsolutePosition,
                    () => AttackAction(unitTile, targetTile, board));
            }
        }
    }

    private void AttackAction(ITile unitTile, ITile targetTile, IBoard board)
    {
        var move = targetTile.Position - unitTile.Position;

        if (Math.Abs(move.X) <= 1 &&
            Math.Abs(move.Y) <= 1)
        {
            unitTile.KillWithMove(targetTile, board);
        }
        else if (Math.Abs(move.X) <= 2 &&
                 Math.Abs(move.Y) <= 2)
        {
            var smallMove = new Position(Math.Sign(move.X), Math.Sign(move.Y));
            var sourcePosition = unitTile.Position;
            
            unitTile.KillWithMove(board[sourcePosition + smallMove], board);
            unitTile = board[sourcePosition + smallMove];
            if (!unitTile.Figure.Type.Equals(this))
                return;
           
            unitTile.KillWithMove(targetTile, board); 
        }
        else
        {
            var smallMove = new Position(Math.Sign(move.X), Math.Sign(move.Y));
            var sourcePosition = unitTile.Position;
            
            unitTile.KillWithMove(board[sourcePosition + smallMove], board);
            unitTile = board[sourcePosition + smallMove];
            if (!unitTile.Figure.Type.Equals(this))
                return;
            
            unitTile.KillWithMove(board[sourcePosition + 2 * smallMove], board);
            unitTile = board[sourcePosition + 2 * smallMove];
            if (!unitTile.Figure.Type.Equals(this))
                return;
            
            unitTile.KillWithMove(targetTile, board);
        }
    }
}