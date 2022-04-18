using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.DefaultFigures.Utilities;

public static class FigureActionHelper
{
    public static void MoveToPosition(this ITile tile, Position position, ITile[] board)
    {
        board[position].Figure = board[tile.Position].Figure;
        board[tile.Position].Figure = new Figure(Player.Neutral, Empty.Instance, 0);
    }

    public static void KillFigure(this ITile tile, ITile[] board)
    {
        board[tile.Position].Figure = new Figure(Player.Neutral, Empty.Instance, 0);
        tile.Figure.Owner.Figures.Remove(tile.Figure);
    }
}
