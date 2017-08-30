using BattleChess3.Figures;

namespace BattleChess3.Game
{
    /// <summary>
    /// Board tools for class Session
    /// </summary>
    public partial class Session
    {
        /// <summary>
        /// Returns BaseFigure at position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static BaseFigure GetFigureAtPosition(Position position)
        {
            return Board[position.X][position.Y];
        }

        /// <summary>
        /// Sets BaseFigure at position
        /// </summary>
        /// <param name="position"></param>
        /// <param name="figure"></param>
        /// <returns></returns>
        public static void SetFigureAtPosition(Position position, BaseFigure figure)
        {
            Board[position.X][position.Y] = figure;
        }

        /// <summary>
        /// Moves figure to position
        /// </summary>
        /// <param name="position"></param>
        /// <param name="newPosition"></param>
        public static void MoveFigureToPosition(Position position, Position newPosition)
        {
            var figure = GetFigureAtPosition(position);
            SetFigureAtPosition(position, new BaseFigure(position));
            SetFigureAtPosition(newPosition, figure);
        }

        /// <summary>
        /// Kills figure at position
        /// </summary>
        /// <param name="position"></param>
        public static void KillFigureAtPosition(Position position)
        {
            SetFigureAtPosition(position, new BaseFigure(position));
        }
        
        /// <summary>
        /// Set binded board
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
    }
}