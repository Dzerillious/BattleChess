using BattleChess3.GameData.Figures;

namespace BattleChess3.Game
{
    /// <summary>
    /// Board tools for class Session
    /// </summary>
    public partial class Session
    {
        public static BaseFigure GetFigureAtPosition(Position position)
        {
            return Board[position.X][position.Y];
        }

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