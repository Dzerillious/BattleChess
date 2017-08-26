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
        /// <summary>
        /// Constructor
        /// </summary>
        public Selected()
        {
            SelFigure = null;
            SelPosition = null;
        }

        /// <summary>
        /// Sets selected by figure
        /// </summary>
        /// <param name="figure"></param>
        public void SetSelected(BaseFigure figure)
        {
            SelFigure = figure;
            SelPosition = figure.Position;
        }

        /// <summary>
        /// Sets selected by position
        /// </summary>
        /// <param name="position"></param>
        public void SetSelected(Position position)
        {
            SelFigure = Play.GetFigureAtPosition(position);
            SelPosition = position;
        }

        private Position _selPosition;

        /// <summary>
        /// Selected position
        /// </summary>
        public Position SelPosition
        {
            get => _selPosition;
            set
            {
                _selPosition = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Selected figure
        /// </summary>
        public BaseFigure SelFigure { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// On ColumnFigures changed
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}