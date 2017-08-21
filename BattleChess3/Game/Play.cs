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
        public static Player WhitePlayer = new Player(Resource.White);
        public static Player BlackPlayer = new Player(Resource.Black);
        public static string WhooseTurn = Resource.White;

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

        public static BoardColumn[] BoardColumns =
        {
            new BoardColumn(),
            new BoardColumn(),
            new BoardColumn(),
            new BoardColumn(),
            new BoardColumn(),
            new BoardColumn(),
            new BoardColumn(),
            new BoardColumn()
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
                var tile = lines[7 - i].Split(' ');
                for (var j = 0; j < 8; j++)
                {
                    if (tile[j].Contains(Resource.White))
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
            if (SelectedPosition == null)
            {
                SelectedPosition = position;
            }
            else
            {
                PlayedPosition = position;
                MakeTurn();
            }
            Highlight();
            SetBoard1D();
        }

        public static void SetBoard1D()
        {
            for (var i = 0; i < 64; i++)
            {
                BoardColumns[i/ 8].ColumnFigures[(63 - i) % 8] = Board[i / 8][i % 8];
            }
        }

        /// <summary>
        /// Recalculates Highlighting
        /// </summary>
        public static void Highlight()
        {
            if (SelectedPosition == null)
            {
                for (var i = 0; i < 64; i++)
                {
                    Board[i / 8][i % 8].Highlighted = null;
                }
            }
            else
            {
                for (var i = 0; i < 64; i++)
                {
                    var position = new Position(i / 8, i % 8);
                    var figure = GetFigureAtPosition(position);
                    figure.Highlighted = null;
                    HighlightDangered(figure);
                    HighlightCanGo(figure);
                    HighlightSelected();
                }
            }
        }

        /// <summary>
        /// Highlights if figure is in danger
        /// </summary>
        /// <param name="figure"></param>
        public static void HighlightDangered(BaseFigure figure)
        {
            if (GetFigureAtPosition(SelectedPosition).CanAttack(figure.Position))
            {
                figure.Highlighted = Resource.Danger;
            }
        }

        /// <summary>
        /// Highlights if can go to tile
        /// </summary>
        /// <param name="figure"></param>
        public static void HighlightCanGo(BaseFigure figure)
        {
            if (GetFigureAtPosition(SelectedPosition).CanMove(figure.Position))
            {
                figure.Highlighted = Resource.CanGo;
            }
        }

        /// <summary>
        /// Highlights selected
        /// </summary>
        public static void HighlightSelected()
        {
            GetFigureAtPosition(SelectedPosition).Highlighted = Resource.Selected;
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
                WhooseTurn = WhooseTurn == Resource.White ? Resource.Black : Resource.White;
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
            SetFigureAtPosition(position, new BaseFigure(Resource.Neutral, position, TypesOfFigures.GetFigureFromString(Resource.Nothing)));
            SetFigureAtPosition(newPosition, figure);
        }

        /// <summary>
        /// Kills figure at position
        /// </summary>
        /// <param name="position"></param>
        public static void KillFigureAtPosition(Position position)
        {
            SetFigureAtPosition(position, new BaseFigure(Resource.Neutral, position, TypesOfFigures.GetFigureFromString(Resource.Nothing)));
        }
    }
}
