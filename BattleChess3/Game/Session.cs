using System.Linq;
using BattleChess3.GameData;
using BattleChess3.GameData.Figures;
using BattleChess3.GameData.Styles;
using BattleChess3.Properties;

namespace BattleChess3.Game
{
    /// <summary>
    /// Class for session of game
    /// </summary>
    public static partial class Session
    {
        public static readonly BaseFigure[][] Board = new BaseFigure[8][];
        public static BoardColumn[] BoardColumns = new BoardColumn[8];
        public static bool[][] CanGoPattern = new bool[8][];
        public static bool[][] CanAttackPattern = new bool[8][];
        public static Player WhitePlayer = new Player(Resource.White);
        public static Player BlackPlayer = new Player(Resource.Black);
        public static string WhooseTurn = Resource.White;
        public static SelectedFigure Selected = new SelectedFigure();
        public static SelectedFigure MouseOn = new SelectedFigure();
        public static Map SelectedMap = new Map();
        public static SelectedStyle SelectedStyle = new SelectedStyle();
        private static Position _playedPosition;

        

        /// <summary>
        /// Sets Selected and Played positions and Plays turn if already selected turns
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
                PlayTurn();
            }
            HighlightTiles();
            SetBindedBoard();
        }

        /// <summary>
        /// Plays turn
        /// </summary>
        public static void PlayTurn()
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
                Selected = new SelectedFigure();
                _playedPosition = null;
            }
        }

        /// <summary>
        /// If map isnt loaded creates empty map. 
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
                        Board[i][j] = new BaseFigure();
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
