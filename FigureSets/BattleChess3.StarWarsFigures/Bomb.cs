using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;
using BattleChess3.Game.Players;

namespace BattleChess3.StarWarsFigures;

public class Bomb : IStarWarsFigureType
{
    public IEnumerable<FigureAction> GetPossibleActions(ITile unitTile, IBoard board)
    {
        return Array.Empty<FigureAction>();
    }

    void IFigureType.OnBeingAttacked(ITile unitTile, ITile attackingTile, IBoard board)
    {
        if (!attackingTile.Figure.Owner.Equals(unitTile.Figure.Owner))
            return;
        
        SilentDie(board, unitTile.Position + (-1, -1));
        SilentDie(board, unitTile.Position + (-1, 0));
        SilentDie(board, unitTile.Position + (-1, 1));
        SilentDie(board, unitTile.Position + (0, -1));
        SilentDie(board, unitTile.Position + (0, 1));
        SilentDie(board, unitTile.Position + (1, -1));
        SilentDie(board, unitTile.Position + (1, 0));
        SilentDie(board, unitTile.Position + (1, 1));
    }

    void IFigureType.OnKilled(ITile unitTile, ITile attackingTile, IBoard board)
    {
        unitTile.Die(board);
    }

    private static void SilentDie(IBoard board, Position position)
    {
        if (!board.TryGetTile(position, out var tile))
            return;

        tile.Figure.Owner.Figures.Remove(tile.Figure);
        tile.Figure = new Figure(Player.Neutral, DefaultFigureGroup.Empty);
    }
}