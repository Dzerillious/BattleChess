using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    public class BoardViewModel : ViewModelBase
    {
        private BoardColumnViewModel[] _columns = new BoardColumnViewModel[8];
        public BoardColumnViewModel[] Columns
        {
            get => _columns;
            set => Set(ref _columns, value);
        }
    }
}