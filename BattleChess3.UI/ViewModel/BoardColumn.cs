using BattleChess3.Core.Figures;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    /// <summary>
    /// One column of board
    /// </summary>
    public class BoardColumn : ViewModelBase
    {
        private BaseFigure[] _columnFigures;
        public BaseFigure[] ColumnFigures
        {
            get => _columnFigures;
            set => Set(ref _columnFigures, value);
        }

        public BoardColumn() => ColumnFigures = new BaseFigure[8];
    }
}