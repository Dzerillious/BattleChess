using BattleChess3.Core.Models;
using BattleChess3.UI.Utilities;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.Services
{
    public class BoardService : ViewModelBase
    {
        public readonly Tile[] Board;
        
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
            Board = new Tile[64];
            for (var i = 0; i < Board.Length; i++)
                Board[i] = Tile.Invalid;
        }
    }
}