using System.IO;
using BattleChess3.Core;
using BattleChess3.UI.ViewModel;

namespace BattleChess3.UI.Services
{
    public class StylingService
    {
        private Style _applicationStyle;
        public Style ApplicationStyle
        {
            get => _applicationStyle ??= new Style(Directory.GetCurrentDirectory() + "\\Resources\\Pictures\\Styles\\PaperStyle");
            set => Set(ref _applicationStyle, value);
        }
    }
}