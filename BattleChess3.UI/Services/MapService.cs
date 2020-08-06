using System.Linq;
using BattleChess3.Core;
using BattleChess3.Core.Figures;
using BattleChess3.UI.ViewModel;

namespace BattleChess3.UI.Services
{
    public class MapService
    {
        public readonly BoardService BoardService = CommonServiceLocator.ServiceLocator.Current.GetInstance<BoardService>();
        public readonly PlayerService PlayerService = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlayerService>();
        public static Map SelectedMap = new Map();

        /// <summary>
        /// If map is not loaded creates empty map.
        /// Calls GetMap
        /// </summary>
        public void LoadMap()
        {
            if (BoardService.Board.Any(column => column == null))
            {
                for (var i = 0; i < 8; i++)
                {
                    BoardService.BoardColumns[i] = new BoardColumnViewModel();
                    BoardService.Board[i] = new Figure[8];
                    for (var j = 0; j < 8; j++)
                    {
                        BoardService.Board[i][j] = new Figure(new Position(i, j));
                        BoardService.BoardColumns[i].ColumnFigures[j] = new Figure(new Position(i, j));
                    }
                }
            }
            else
            {
                foreach (var column in BoardService.Board)
                foreach (var tile in column)
                    KillFigure(tile);
            }
            GetMap();
        }

        /// <summary>
        /// Gets Map from selected map and sets figures
        /// Saves data to session
        /// </summary>
        public void GetMap()
        {
            PlayerService.CurrentPlayer = SelectedMap.StartingPlayer;
            for (var i = 0; i < SelectedMap.Figure.Length; i++)
            {
                var tile = SelectedMap.Figure[i];
                for (var j = 0; j < tile.Length; j++)
                {
                    var position = new Position(j, i);
                    if (tile[j] == "Nothing") BoardService.CreateFigure(tile[j], position, Player.Neutral);
                    else if (tile[j].Contains(1.ToString()))
                        BoardService.CreateFigure(tile[j], position, PlayerService.Players[1]);
                    else if (tile[j].Contains(2.ToString()))
                        BoardService.CreateFigure(tile[j], position, PlayerService.Players[2]);
                    else BoardService.CreateFigure(tile[j], position, PlayerService.Players[0]);
                }
            }
        }
    }
}