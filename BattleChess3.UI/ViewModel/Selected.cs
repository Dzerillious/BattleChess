using BattleChess3.Core;
using BattleChess3.Core.Figures;
using BattleChess3.UI.Game;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.ViewModel
{
    public class Selected : ViewModelBase
    {
        public Position Position { get; set; }

        private BaseFigure _figure;
        public BaseFigure Figure
        {
            get => _figure;
            set => Set(ref _figure, value);
        }

        public Selected()
        {
            Figure = new BaseFigure();
            Position = Position.Invalid;
        }

        public void SetSelected(BaseFigure figure)
        {
            Figure = figure;
            Position = figure.Position;
        }

        public void SetSelected(Position position)
        {
            Figure = Session.GetFigureAtPosition(position);
            Position = position;
        }
    }
}