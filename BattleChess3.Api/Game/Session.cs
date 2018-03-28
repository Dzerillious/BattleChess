using BattleChess3.Api.ViewModel;
using BattleChess3.Model;
using BattleChess3.Model.Figures;
using BattleChess3.Shared;
using BattleChess3.Shared.Properties;

namespace BattleChess3.Api.Game
{
    /// <summary>
    /// Class for session of game
    /// </summary>
    public static partial class Session
    {
        public static SelectedFigure Selected = new SelectedFigure();
        public static SelectedFigure MouseOn = new SelectedFigure();
        public static SelectedStyle SelectedStyle = new SelectedStyle();
        public static Map SelectedMap = new Map();

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
            if (TryPlay(figure, _playedPosition) == false)
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
    }
}