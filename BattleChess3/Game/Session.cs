using System.IO;
using BattleChess3.Figures;
using BattleChess3.Menu;
using BattleChess3.Properties;

namespace BattleChess3.Game
{
    /// <summary>
    /// Class for game
    /// </summary>
    public static partial class Session
    {
        private static readonly BaseFigure[][] Board = new BaseFigure[8][];
        public static BoardColumn[] BoardColumns = new BoardColumn[8];
        public static bool[][] CanGoPattern = new bool[8][];
        public static bool[][] CanAttackPattern = new bool[8][];
        public static Player WhitePlayer = new Player(Resource.White);
        public static Player BlackPlayer = new Player(Resource.Black);
        public static string WhooseTurn = Resource.White;
        public static Selected Selected = new Selected();
        public static Selected MouseOn = new Selected();
        private static Position _playedPosition;

        

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
                _playedPosition = position;
                MakeTurn();
            }
            HighlightTiles();
            SetBindedBoard();
        }

        /// <summary>
        /// Plays turn
        /// </summary>
        public static void MakeTurn()
        {
            var figure = Selected.SelFigure;
            if (figure.TryPlay(_playedPosition) == false)
            {
                Selected.SetSelected(_playedPosition);
                _playedPosition = null;
            }
            else
            {
                WhooseTurn = WhooseTurn == Resource.White ? Resource.Black : Resource.White;
                Selected = new Selected();
                _playedPosition = null;
            }
        }

        /// <summary>
        /// Loads map and creates figures
        /// </summary>
        public static void LoadMap(string mapName)
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
            foreach (var map in Maps.Map)
            {
                if (map.Name == mapName)
                {
                    GetMap(map);
                }
            }
        }

        public static void GetMap(Map map)
        {
            for (var i = 0; i < map.Figure.Length; i++)
            {
                var tile = map.Figure[i];
                for (var j = 0; j < tile.Length; j++)
                {
                    var position = new Position(j, i);
                    BaseFigure newBaseFigure;
                    if (tile[j] == "Nothing")
                    {
                        newBaseFigure = new BaseFigure(position);
                    }
                    else if (tile[j].Contains(Resource.White))
                    {
                        var figure = TypesOfFigures.GetFigureFromString(tile[j].Replace(Resource.White, ""));
                        newBaseFigure = new BaseFigure(Resource.White, position, figure);
                        WhitePlayer.CreateFigure(newBaseFigure);
                    }
                    else if (tile[j].Contains(Resource.Black))
                    {
                        var figure = TypesOfFigures.GetFigureFromString(tile[j].Replace(Resource.Black, ""));
                        newBaseFigure = new BaseFigure(Resource.Black, position, figure);
                        BlackPlayer.CreateFigure(newBaseFigure);
                    }
                    else
                    {
                        var figure = TypesOfFigures.GetFigureFromString(tile[j]);
                        newBaseFigure = new BaseFigure(Resource.Neutral, position, figure);
                    }
                    SetFigureAtPosition(position, newBaseFigure);
                }
            }
        }
    }
}
