using BattleChess3.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattleChess3.Api.ViewModel
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
                    var filePaths = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\Pictures\\Styles");
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