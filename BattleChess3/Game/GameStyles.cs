using System.Linq;
using BattleChess3.Game.Styles;

namespace BattleChess3.Game
{
    public static class GameStyles
    {
        private static IStyle[] _styles;
        /// <summary>
        /// Array of Styles of application
        /// </summary>
        public static IStyle[] Styles => _styles ?? (_styles = new IStyle[]
        {
            new PaperStyle(),
            new SciFiStyle(), 
            new RoughPaperStyle(), 
        });

        public static IStyle GetStyleFromString(string text) => Styles.FirstOrDefault(style => style.Name == text);
    }
}