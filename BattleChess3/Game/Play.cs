using System.IO;
using BattleChess3.Figures;
using BattleChess3.Properties;

namespace BattleChess3.Game
{
    /// <summary>
    /// Class for game
    /// </summary>
    public static partial class Play
    {
        public static Player WhitePlayer = new Player(Resource.White);
        public static Player BlackPlayer = new Player(Resource.Black);
        public static string WhooseTurn = Resource.White;
        public static Selected Selected = new Selected();
        public static Selected MouseOn = new Selected();
        public static Position PlayedPosition;
        public static BaseFigure[][] Board = new BaseFigure[8][];
        public static BoardColumn[] BoardColumns = new BoardColumn[8];

        /// <summary>
        /// Loads map and creates figures
        /// </summary>
        public static void LoadMap(string filePath)
        {
            for (var i = 0; i < 8; i++)
            {
                BoardColumns[i] = new BoardColumn();
                Board[i] = new BaseFigure[8];
                for (var j = 0; j < 8; j++)
                {
                    Board[i][j] = new BaseFigure();
                }
            }
            var lines = File.ReadAllLines(filePath);
            for (var i = 0; i < 8; i++)
            {
                var tile = lines[7 - i].Split(' ');
                for (var j = 0; j < 8; j++)
                {
                    if (tile[j] == "Nothing")
                    {
                        Board[j][i] = new BaseFigure(new Position(j, i));
                    }
                    else if (tile[j].Contains(Resource.White))
                    {
                        var figure = TypesOfFigures.GetFigureFromString(tile[j].Replace(Resource.White, ""));
                        Board[j][i] = new BaseFigure(Resource.White, new Position(j, i), figure);
                        WhitePlayer.CreateFigure(Board[j][i]);
                    }
                    else if (tile[j].Contains(Resource.Black))
                    {
                        var figure = TypesOfFigures.GetFigureFromString(tile[j].Replace(Resource.Black, ""));
                        Board[j][i] = new BaseFigure(Resource.Black, new Position(j, i), figure);
                        BlackPlayer.CreateFigure(Board[j][i]);
                    }
                    else
                    {
                        var figure = TypesOfFigures.GetFigureFromString(tile[j]);
                        Board[j][i] = new BaseFigure(Resource.Neutral, new Position(j, i), figure);
                    }
                }
            }
        }

        /// <summary>
        /// Sets Selected and Played positions and Makes turns
        /// </summary>
        /// <param name="position"></param>
        public static void ClickedAtPosition(Position position)
        {
            if (Selected.SelPosition == null)
            {
                Selected.SetSelected(position);
            }
            else
            {
                PlayedPosition = position;
                MakeTurn();
            }
            HighlightTiles();
            SetBindedBoard();
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

        /// <summary>
        /// Plays turn
        /// </summary>
        public static void MakeTurn()
        {
            var figure = Selected.SelFigure;
            if (figure.TryPlay(PlayedPosition) == false)
            {
                Selected.SetSelected(PlayedPosition);
                PlayedPosition = null;
            }
            else
            {
                WhooseTurn = WhooseTurn == Resource.White ? Resource.Black : Resource.White;
                Selected = new Selected();
                PlayedPosition = null;
            }
        }

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
    }
}
