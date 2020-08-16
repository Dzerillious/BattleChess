using BattleChess3.Core.Models;
using BattleChess3.UI.Utilities;

namespace BattleChess3.UI.Services
{
    public class BoardService
    {
        public Tile SelectedTile = TileHelper.Invalid;
        public Tile HoverTile = TileHelper.Invalid;
        public readonly Tile[] Board;

        public BoardService()
        {
            Board = new Tile[64];
            for (var i = 0; i < Board.Length; i++)
                Board[i] = TileHelper.Invalid;
        }

        // public void MoveFigureToPosition(Position position, Position newPosition)
        // {
        //     var figure = GetFigureAtPosition(position);
        //     SetFigureAtPosition(position, FigureHelper.Empty);
        //     SetFigureAtPosition(newPosition, figure);
        // }
        //
        // public void KillFigureAtTile(Tile tile)
        // {
        //     SetFigureAtPosition(tile.Position, FigureHelper.Empty);
        //     tile.Figure.Owner.Figures.Remove(tile.Figure);
        // }
    }
}