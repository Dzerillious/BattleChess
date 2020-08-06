using BattleChess3.Core;
using BattleChess3.Core.Figures;
using BattleChess3.UI.ViewModel;

namespace BattleChess3.UI.Services
{
    public class BoardService
    {
        public readonly PlayerService PlayerService = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlayerService>();
        
        public SelectedTile SelectedTile = new SelectedTile();
        public SelectedTile HoverTile = new SelectedTile();
        public static readonly Figure[][] Board = new Figure[8][];

        public static Figure GetFigureAtPosition(Position position)
        {
            return Board[position.X][position.Y];
        }
        
        public static void CreateFigure(string tile, Position position, Player player)
        {
            var figure = TypesOfFigures.GetFigureFromString(tile.Replace(player.Id.ToString(), ""));
            Figure newFigure = new Figure(player, figure);
            player?.Figures.Add(newFigure);
            SetFigureAtPosition(position, newFigure);
        }

        public static void SetFigureAtPosition(Position position, Figure figure)
        {
            Board[position.X][position.Y] = figure;
        }

        public static void MoveFigureToPosition(Position position, Position newPosition)
        {
            var figure = GetFigureAtPosition(position);
            SetFigureAtPosition(position, Figure.Empty);
            SetFigureAtPosition(newPosition, figure);
        }

        public static void KillFigure(Figure figure)
        {
            SetFigureAtPosition(figure.Position, new Figure(figure.Position));
            figure.Owner.Figures.Remove(figure);
        }
    }
}