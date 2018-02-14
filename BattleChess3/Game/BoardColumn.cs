using System.ComponentModel;
using System.Runtime.CompilerServices;
using BattleChess3.Annotations;
using BattleChess3.GameData.Figures;

namespace BattleChess3.Game
{
    /// <summary>
    /// One column of board
    /// </summary>
    public class BoardColumn : INotifyPropertyChanged
    {
        private BaseFigure[] _columnFigures;
        
        public BaseFigure[] ColumnFigures
        {
            get => _columnFigures;
            set
            {
                _columnFigures = value;
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        /// Constructor for empty Board column
        /// </summary>
        public BoardColumn() => ColumnFigures = new BaseFigure[8];

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// On ColumnFigures changed notify to change view
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
