using System.IO;
using BattleChess3.Figures;
using BattleChess3.Properties;

namespace BattleChess3.Game
{
    /// <summary>
    /// Class for game
    /// </summary>
    public static class Play
    {
        public static Player WhitePlayer = new Player(Resources.White);
        public static Player BlackPlayer = new Player(Resources.Black);
        public static string WhooseTurn = Resources.White;

        public static BaseFigure[][] Board =
        {
            new BaseFigure[8],
            new BaseFigure[8],
            new BaseFigure[8],
            new BaseFigure[8],
            new BaseFigure[8],
            new BaseFigure[8],
            new BaseFigure[8],
            new BaseFigure[8],
        };

        public static Position SelectedPosition;
        public static Position PlayedPosition;

        /// <summary>
        /// Loads map and creates figures
        /// </summary>
        public static void LoadMap(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            for (var i = 0; i < 8; i++)
            {
                var tile = lines[7-i].Split(' ');
                for (var j = 0; j < 8; j++)
                {
                    if (tile[j] == "Nothing") continue;
                    if (tile[j].Contains(Resources.White))
                    {
                        var figure = TypesOfFigures.GetFigureFromString(tile[j].Replace(Resources.White, ""));
                        Board[j][i] = new BaseFigure(Resources.White, new Position(j, i), figure);
                        WhitePlayer.CreateFigure(Board[j][i]);
                    }
                    else
                    {
                        var figure = TypesOfFigures.GetFigureFromString(tile[j].Replace(Resources.Black, ""));
                        Board[j][i] = new BaseFigure(Resources.Black, new Position(j, i), figure);
                        BlackPlayer.CreateFigure(Board[j][i]);
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
            if (SelectedPosition == null)
            {
                SelectedPosition = position;
            }
            else
            {
                PlayedPosition = position;
                MakeTurn();
            }
        }

        /// <summary>
        /// Plays turn
        /// </summary>
        public static void MakeTurn()
        {
            var figure = GetFigureAtPosition(SelectedPosition);
            if (figure.TryPlay(PlayedPosition) == false)
            {
                SelectedPosition = PlayedPosition;
                PlayedPosition = null;
            }
            else
            {
                WhooseTurn = WhooseTurn == Resources.White ? Resources.Black : Resources.White;
                SelectedPosition = null;
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
            SetFigureAtPosition(position, null);
            SetFigureAtPosition(newPosition, figure);
        }

        /// <summary>
        /// Kills figure at position
        /// </summary>
        /// <param name="position"></param>
        public static void KillFigureAtPosition(Position position)
        {
            SetFigureAtPosition(position, null);
        }
    }
}
