using BattleChess3.Core.Model;

namespace BattleChess3.DefaultFigures.Utilities
{
    public static class FigureActionHelper
    {
        public static void MoveToPosition(this Tile tile, Position position, Tile[] board)
        {
            board[position].Figure = board[tile.Position].Figure;
            board[tile.Position].Figure = Empty.Figure;
        }

        public static void KillFigure(this Tile tile, Tile[] board)
        {
            board[tile.Position].Figure = Empty.Figure;
            tile.Figure.Owner.Figures.Remove(tile.Figure);
        }
    }
}