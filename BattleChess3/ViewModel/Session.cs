using BattleChess3.Model;
using BattleChess3.Model.Figures;
using BattleChess3.Properties;
using BattleChess3.ViewModel.Styles;

namespace BattleChess3.ViewModel
{
    /// <summary>
    /// Class for session of game
    /// </summary>
    public static partial class Session
    {
        public static Player WhitePlayer = new Player(Resource.White);
        public static Player BlackPlayer = new Player(Resource.Black);

        public static SelectedFigure Selected = new SelectedFigure();
        public static SelectedFigure MouseOn = new SelectedFigure();
        public static Map SelectedMap = new Map();
        public static SelectedStyle SelectedStyle = new SelectedStyle();

        public static string WhooseTurn = Resource.White;
        private static Position _playedPosition;

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
            SetBindedBoard();
            HighlightTiles();
        }

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

        private static void CreateFigure(string tile, Position position, string playerName, Player player = null)
        {
            var figure = TypesOfFigures.GetFigureFromString(tile.Replace(playerName, ""));
            BaseFigure newBaseFigure = new BaseFigure(playerName, position, figure);
            player?.CreateFigure(newBaseFigure);
            SetFigureAtPosition(position, newBaseFigure);
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
                    else if (tile[j].Contains(Resource.White))
                        CreateFigure(tile[j], position, Resource.White, WhitePlayer);
                    else if (tile[j].Contains(Resource.Black))
                        CreateFigure(tile[j], position, Resource.Black, BlackPlayer);
                    else CreateFigure(tile[j], position, Resource.Neutral);
                }
            }
        }
    }
}