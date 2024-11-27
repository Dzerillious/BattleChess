using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;
using BattleChess3.Game.Players;

namespace BattleChess3.CrossFireFigures;

public class Bomber : ICrossFireFigureType
{
    private readonly Position[] _positions = 
    {
        (-2, -2), (-2, 0), (-2, 2),
        (0, -2), (0, 2),
        (2, -2), (2, 0), (2, 2)
    };

    IEnumerable<FigureAction> IFigureType.GetPossibleActions(ITile unitTile, IBoard board)
    {
        foreach (var movement in _positions)
        {
            var position = unitTile.Position + movement;
            if (!board.TryGetTile(position, out var targetTile))
                continue;
            
            if (targetTile.IsEmpty())
            {
                yield return unitTile.CreateMoveAction(targetTile, board);
            }
        }
    }

    void IFigureType.OnMoved(ITile unitTile, ITile targetTile, IBoard board)
    {
        SilentDie(board, targetTile.Position + (-1, -1));
        SilentDie(board, targetTile.Position + (-1, 0));
        SilentDie(board, targetTile.Position + (-1, 1));
        SilentDie(board, targetTile.Position + (0, -1));
        SilentDie(board, targetTile.Position + (0, 0));
        SilentDie(board, targetTile.Position + (0, 1));
        SilentDie(board, targetTile.Position + (1, -1));
        SilentDie(board, targetTile.Position + (1, 0));
        SilentDie(board, targetTile.Position + (1, 1));
    }

    private static void SilentDie(IBoard board, Position position)
    {
        if (!board.TryGetTile(position, out var tile))
            return;

        tile.Figure.Owner.Figures.Remove(tile.Figure);
        tile.Figure = new Figure(Player.Neutral, DefaultFigureGroup.Empty);
    }
}