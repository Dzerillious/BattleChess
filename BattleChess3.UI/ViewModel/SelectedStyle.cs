using System.IO;
using BattleChess3.Core;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    public class SelectedStyle : ViewModelBase
    {
        private Style _applicationStyle;

        /// <summary>
        /// Property for Application Style
        /// </summary>
        public Style ApplicationStyle
        {
            get => _applicationStyle ??= new Style(Directory.GetCurrentDirectory() + "\\Resources\\Pictures\\Styles\\PaperStyle");
            set => Set(ref _applicationStyle, value);
        }
    }
}