using BattleChess3.Core;
using BattleChess3.UI.Properties;
using BattleChess3.UI.ViewModel;

namespace BattleChess3.UI.Game
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

        public static int WhooseTurn = 1;
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
                WhooseTurn = WhooseTurn == 1 ? 2 : 1;
                Selected = new SelectedFigure();
                _playedPosition = null;
            }
        }
    }
}