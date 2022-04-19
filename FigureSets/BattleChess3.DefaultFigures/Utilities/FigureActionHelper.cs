using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.DefaultFigures.Utilities;

public static class FigureActionHelper
{
    public static void MoveToPosition(this ITile[] board, ITile tile, Position position)
    {
        board[position].Figure = board[tile.Position].Figure;
        board[tile.Position].Figure = new Figure(Player.Neutral, Empty.Instance, 0);
    }

    public static void KillFigureWithMove(this ITile[] board, ITile unit, ITile tile)
    {
        board[tile.Position].Figure = new Figure(Player.Neutral, Empty.Instance, 0);
        tile.Figure.Owner.Figures.Remove(tile.Figure);
        board.MoveToPosition(unit, tile.Position);
    }
}
