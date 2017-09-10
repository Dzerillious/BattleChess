using System.IO;
using System.Linq;
using BattleChess3.GameData.Styles;

namespace BattleChess3.GameData
{
    public static class GameStyles
    {
        private static Style[] _styles;

        /// <summary>
        /// Array of Styles of application
        /// </summary>
        public static Style[] Styles
        {
            get
            {
                if (_styles == null)
                {
                    var filePaths = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\Pictures\\Styles");
                    var styles = new Style[filePaths.Length];
                    for (var i = 0; i < filePaths.Length && i < 100; i++)
                    {
                        styles[i] = new Style(filePaths[i]);
                    }
                    _styles = styles;
                }
                return _styles;
            }
        }

        public static Style GetStyleFromString(string text) => Styles.FirstOrDefault(style => style.Name == text);
    }
}