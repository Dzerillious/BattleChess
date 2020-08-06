using BattleChess3.Core;
using BattleChess3.Core.Figures;

namespace BattleChess3.UI.Services
{
    public class BoardService
    {
        public Tile SelectedTile = Tile.Invalid;
        public Tile HoverTile = Tile.Invalid;
        public readonly Tile[] Board = new Tile[64];

        public Figure GetFigureAtPosition(Position position) 
            => Board[position].Figure;

        public Tile GetTileAtPosition(Position position) 
            => Board[position];

        public void CreateFigure(string tile, Position position, Player player)
        {
            var figure = TypesOfFigures.GetFigureFromString(tile.Replace(player.Id.ToString(), ""));
            Figure newFigure = new Figure(player, figure);
            player?.Figures.Add(newFigure);
            SetFigureAtPosition(position, newFigure);
        }

        public void SetFigureAtPosition(Position position, Figure figure)
        {
            Board[position].Figure = figure;
        }

        public void MoveFigureToPosition(Position position, Position newPosition)
        {
            var figure = GetFigureAtPosition(position);
            SetFigureAtPosition(position, Figure.Empty);
            SetFigureAtPosition(newPosition, figure);
        }

        public void KillFigureAtTile(Tile tile)
        {
            SetFigureAtPosition(tile.Position, Figure.Empty);
            tile.Figure.Owner.Figures.Remove(tile.Figure);
        }
    }
}