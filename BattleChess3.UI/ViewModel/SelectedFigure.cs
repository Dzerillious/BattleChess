using BattleChess3.Core;
using BattleChess3.Core.Figures;
using BattleChess3.UI.Game;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    public class SelectedFigure : ViewModelBase
    {
        public Position SelPosition { get; set; }

        private BaseFigure _selFigure;
        public BaseFigure SelFigure
        {
            get => _selFigure;
            set => Set(ref _selFigure, value);
        }

        public SelectedFigure()
        {
            SelFigure = new BaseFigure();
            SelPosition = null;
        }

        public void SetSelected(BaseFigure figure)
        {
            SelFigure = figure;
            SelPosition = figure.Position;
        }

        public void SetSelected(Position position)
        {
            SelFigure = Session.GetFigureAtPosition(position);
            SelPosition = position;
        }
    }
}