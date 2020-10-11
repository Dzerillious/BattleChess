using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.DefaultFigures.Utilities
{
    public static class FigureActionHelper
    {
        public static void MoveToPosition(this Tile tile, Position position, Tile[] board)
        {
            board[position].Figure = board[tile.Position].Figure;
            board[tile.Position].Figure = new Figure(Player.Neutral, Empty.Instance, 0);
        }

        public static void KillFigure(this Tile tile, Tile[] board)
        {
            board[tile.Position].Figure = new Figure(Player.Neutral, Empty.Instance, 0);
            tile.Figure.Owner.Figures.Remove(tile.Figure);
        }
    }
}