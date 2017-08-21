using System.ComponentModel;
using System.Runtime.CompilerServices;
using BattleChess3.Annotations;
using BattleChess3.Figures;

namespace BattleChess3.Game
{
    /// <summary>
    /// One column of board
    /// </summary>
    public class BoardColumn : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BoardColumn()
        {
            ColumnFigures = new BaseFigure[8];
        }

        private BaseFigure[] _columnFigures;
        /// <summary>
        /// Column of figures
        /// </summary>
        public BaseFigure[] ColumnFigures
        {
            get => _columnFigures;
            set
            {
                _columnFigures = value;
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
