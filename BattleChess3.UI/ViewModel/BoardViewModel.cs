using BattleChess3.Core.Model;
using BattleChess3.Core.Resources;
using BattleChess3.UI.Services;
using CommonServiceLocator;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    public class BoardViewModel : ViewModelBase
    {
        private readonly BoardService _boardService 
            = ServiceLocator.Current.GetInstance<BoardService>();
        
        private TileViewModel[] _tiles = new TileViewModel[Constants.BoardSize];
        public TileViewModel[] Tiles
        {
            get => _tiles;
            set => Set(ref _tiles, value);
        }

        public BoardViewModel()
        {
            for (var i = 0; i < Constants.BoardSize; i++)
            {
                Position position = i;
                var tile = Tiles[i] = new TileViewModel(position);
                if (_boardService.Board[position].Position != Position.Invalid)
                    tile.Figure = _boardService.Board[position].Figure;
                _boardService.Board[position] = tile;
            }
        }
    }
}