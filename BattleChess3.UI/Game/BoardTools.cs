using System.Linq;
using BattleChess3.Core;
using BattleChess3.Core.Figures;
using BattleChess3.UI.Properties;
using BattleChess3.UI.ViewModel;

namespace BattleChess3.UI.Game
{
    public static partial class Session
    {
        public static BoardColumn[] BoardColumns = new BoardColumn[8];
        public static readonly BaseFigure[][] Board = new BaseFigure[8][];

        /// <summary>
        /// Sets binded board for view to show game board
        /// </summary>
        public static void SetBindedBoard()
        {
            for (var i = 0; i < 8; i++)
            {
                var newColumn = new BoardColumn();
                for (var j = 0; j < 8; j++)
                {
                    newColumn.ColumnFigures[j] = Board[i][j];
                }
                BoardColumns[i].ColumnFigures = newColumn.ColumnFigures;
            }
        }

        /// <summary>
        /// If map is not loaded creates empty map.
        /// Calls GetMap
        /// </summary>
        public static void LoadMap()
        {
            if (Board.Any(column => column == null))
            {
                for (var i = 0; i < 8; i++)
                {
                    BoardColumns[i] = new BoardColumn();
                    Board[i] = new BaseFigure[8];
                    for (var j = 0; j < 8; j++)
                    {
                        Board[i][j] = new BaseFigure(new Position(i, j));
                        BoardColumns[i].ColumnFigures[j] = new BaseFigure(new Position(i, j));
                    }
                }
            }
            else
            {
                foreach (var column in Board)
                {
                    foreach (var tile in column)
                    {
                        KillFigure(tile);
                    }
                }
            }
            GetMap();
        }

        /// <summary>
        /// Gets Map from selected map and sets figures
        /// Saves data to session
        /// </summary>
        public static void GetMap()
        {
            WhooseTurn = SelectedMap.StartingPlayer;
            for (var i = 0; i < SelectedMap.Figure.Length; i++)
            {
                var tile = SelectedMap.Figure[i];
                for (var j = 0; j < tile.Length; j++)
                {
                    var position = new Position(j, i);
                    BaseFigure newBaseFigure;
                    if (tile[j] == "Nothing")
                        newBaseFigure = new BaseFigure(position);
                    else if (tile[j].Contains(1.ToString()))
                        CreateFigure(tile[j], position, 1, WhitePlayer);
                    else if (tile[j].Contains(2.ToString()))
                        CreateFigure(tile[j], position, 2, BlackPlayer);
                    else CreateFigure(tile[j], position, 0);
                }
            }
        }
    }
}