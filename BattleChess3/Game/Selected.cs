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
            SelFigure = new BaseFigure();
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
            SelFigure = Session.GetFigureAtPosition(position);
            SelPosition = position;
        }

        /// <summary>
        /// Selected position
        /// </summary>
        public Position SelPosition { get; set; }

        private BaseFigure _selFigure;
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