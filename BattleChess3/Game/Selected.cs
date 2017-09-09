using System.ComponentModel;
using System.Runtime.CompilerServices;
using BattleChess3.Annotations;
using BattleChess3.Figures;

namespace BattleChess3.Game
{
    /// <summary>
    /// Selected position data
    /// </summary>
    public class Selected : INotifyPropertyChanged
    {
        private BaseFigure _selFigure;
        
        public Position SelPosition { get; set; }
        public BaseFigure SelFigure
        {
            get => _selFigure;
            set
            {
                _selFigure = value;
                OnPropertyChanged();
            }
        }
        
        public Selected()
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


        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// On SelectedFigure changed
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}