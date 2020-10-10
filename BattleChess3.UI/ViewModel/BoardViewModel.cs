using BattleChess3.Core.Models;
using BattleChess3.UI.Services;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    public class BoardViewModel : ViewModelBase
    {
        private readonly BoardService _boardService =
            CommonServiceLocator.ServiceLocator.Current.GetInstance<BoardService>();
        
        private BoardColumnViewModel[] _columns = new BoardColumnViewModel[8];
        public BoardColumnViewModel[] Columns
        {
            get => _columns;
            set => Set(ref _columns, value);
        }

        public BoardViewModel()
        {
            Columns = new BoardColumnViewModel[8];
            for (var i = 0; i < 8; i++)
            {
                var column = Columns[i] = new BoardColumnViewModel();
                column.Tiles = new TileViewModel[8];
                for (var j = 0; j < 8; j++)
                {
                    Position position = (i, j);
                    var tile = column.Tiles[j] = new TileViewModel(position);
                    if (_boardService.Board[position].Position != Position.Invalid)
                        tile.Figure = _boardService.Board[position].Figure;
                    _boardService.Board[position] = tile;
                }
            }
        }
    }
}