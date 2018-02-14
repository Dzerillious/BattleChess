using System.ComponentModel;
using System.Runtime.CompilerServices;
using BattleChess3.Annotations;
using BattleChess3.GameData.Figures;

namespace BattleChess3.Game
{
    /// <summary>
    /// Selected position data
    /// </summary>
    public class SelectedFigure : INotifyPropertyChanged
    {
        private BaseFigure _selFigure;
        
        public Position SelPosition { get; set; }
        /// <summary>
        /// Selected figure
        /// </summary>
        public BaseFigure SelFigure
        {
            get => _selFigure;
            set
            {
                _selFigure = value;
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// Empty selected figure
        /// </summary>
        public SelectedFigure()
        {
            SelFigure = new BaseFigure();
            SelPosition = null;
        }

        /// <summary>
        /// Set selected to figure
        /// </summary>
        public void SetSelected(BaseFigure figure)
        {
            SelFigure = figure;
            SelPosition = figure.Position;
        }

        /// <summary>
        /// Set selected to position
        /// </summary>
        public void SetSelected(Position position)
        {
            SelFigure = Session.GetFigureAtPosition(position);
            SelPosition = position;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// On SelectedFigure changed raise event
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}