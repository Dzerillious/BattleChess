using System.Collections.Generic;
using System.IO;
using System.Linq;
using BattleChess3.Core;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.Services
{
    public class StyleOptions : ViewModelBase
    {
        private Style _applicationStyle;
        public Style ApplicationStyle
        {
            get => _applicationStyle ??= new Style(Directory.GetCurrentDirectory() + "\\Resources\\Pictures\\Styles\\PaperStyle");
            set => Set(ref _applicationStyle, value);
        }
        
        private List<Style> _styles = new List<Style>();
        public List<Style> Styles
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

        public Style GetStyleFromString(string text) => Styles.FirstOrDefault(style => style.Name == text);
    }
}