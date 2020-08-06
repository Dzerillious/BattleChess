using System.Collections.Generic;
using System.IO;
using System.Linq;
using BattleChess3.Core;

namespace BattleChess3.UI.ViewModel
{
    public static class GameStyles
    {
        private static List<Style> _styles = new List<Style>();
        public static List<Style> Styles
        {
            get
            {
                if (_styles.Count == 0)
                {
                    var filePaths = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\Resources\\Pictures\\Styles");
                    var newStyles = new List<Style>();
                    foreach (var path in filePaths)
                    {
                        newStyles.Add(new Style(path));
                    }
                    _styles = newStyles;
                }
                return _styles;
            }
        }

        public static Style GetStyleFromString(string text) => Styles.FirstOrDefault(style => style.Name == text);
    }
}