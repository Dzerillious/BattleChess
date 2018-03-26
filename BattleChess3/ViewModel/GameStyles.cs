using BattleChess3.GameData.Styles;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattleChess3.GameData
{
    public static class GameStyles
    {
        private static List<Style> styles = new List<Style>();

        public static List<Style> Styles
        {
            get
            {
                if (styles == null)
                {
                    var filePaths = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\Pictures\\Styles");
                    var newStyles = new List<Style>();
                    foreach (var path in filePaths)
                    {
                        styles.Add(new Style(path));
                    }
                    styles = newStyles;
                }
                return styles;
            }
        }

        public static Style GetStyleFromString(string text) => Styles.FirstOrDefault(style => style.Name == text);
    }
}