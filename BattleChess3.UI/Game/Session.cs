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
        public static Selected Selected = new Selected();
        public static Selected MouseOn = new Selected();
        public static SelectedStyle SelectedStyle = new SelectedStyle();
        public static Map SelectedMap = new Map();

        public static int WhooseTurn = 1;
        private static Position _playedPosition;

        public static void ClickedAtPosition(Position position)
        {
            if (Selected.Position == Position.Invalid)
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
            var figure = Selected.Figure;
            if (TryPlay(figure, _playedPosition) == false)
            {
                Selected.SetSelected(_playedPosition);
                _playedPosition = Position.Invalid;
            }
            else
            {
                WhooseTurn = WhooseTurn == 1 ? 2 : 1;
                Selected = new Selected();
                _playedPosition = Position.Invalid;
            }
        }
    }
}