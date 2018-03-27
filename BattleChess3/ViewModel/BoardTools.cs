using BattleChess3.Model.Figures;
using System.Linq;

namespace BattleChess3.ViewModel
{
    public static partial class Session
    {
        public static BoardColumn[] BoardColumns = new BoardColumn[8];
        public static readonly BaseFigure[][] Board = new BaseFigure[8][];

        public static BaseFigure GetFigureAtPosition(Position position) => Board[position.X][position.Y];

        public static void SetFigureAtPosition(Position position, BaseFigure figure)
        {
            Board[position.X][position.Y] = figure;
        }

        public static void MoveFigureToPosition(Position position, Position newPosition)
        {
            var figure = GetFigureAtPosition(position);
            SetFigureAtPosition(position, new BaseFigure(position));
            SetFigureAtPosition(newPosition, figure);
        }

        public static void KillFigureAtPosition(Position position)
        {
            SetFigureAtPosition(position, new BaseFigure(position));
        }

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
        /// If map isn' t loaded creates empty map.
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
                        tile.Die();
                    }
                }
            }
            GetMap();
        }
    }
}