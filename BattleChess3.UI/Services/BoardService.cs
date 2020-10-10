using BattleChess3.Core.Model;
using BattleChess3.Core.Resources;
using BattleChess3.UI.ViewModel;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.Services
{
    public class BoardService : ViewModelBase
    {
        public Tile[] Board { get; }
        
        private Tile _selectedTile = Tile.Invalid;
        public Tile SelectedTile
        {
            get => _selectedTile;
            set
            {
                _selectedTile.IsSelected = false;
                Set(ref _selectedTile, value);
                value.IsSelected = true;
            }
        }

        private Tile _mouseOnTile = Tile.Invalid;
        public Tile MouseOnTile
        {
            get => _mouseOnTile;
            set
            {
                _mouseOnTile.IsMouseOver = false;
                Set(ref _mouseOnTile, value);
                value.IsMouseOver = true;
            }
        }
        
        public BoardService()
        {
            var board = new Tile[Constants.BoardSize];
            for (var i = 0; i < Constants.BoardSize; i++)
            {
                Position position = i;
                board[i] = new TileViewModel(position);
            }
            Board = board;
        }
    }
}