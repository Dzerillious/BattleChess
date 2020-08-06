using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    /// <summary>
    /// One column of board
    /// </summary>
    public class BoardColumnViewModel : ViewModelBase
    {
        private TileViewModel[] _tiles = new TileViewModel[8];
        public TileViewModel[] ColumnFigures
        {
            get => _tiles;
            set => Set(ref _tiles, value);
        }
    }
}