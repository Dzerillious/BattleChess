using System.Linq;
using BattleChess3.Core.Model;
using BattleChess3.Core.Resources;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.Services
{
    public class BoardService : ViewModelBase
    {
        public readonly Tile[] Board = Enumerable.Repeat(Tile.Invalid, Constants.BoardSize).ToArray();
        
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
    }
}