using BattleChess3.Annotations;
using BattleChess3.Model.Figures;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BattleChess3.ViewModel
{
    /// <summary>
    /// One column of board
    /// </summary>
    public class BoardColumn : INotifyPropertyChanged
    {
        private BaseFigure[] columnFigures;

        public BaseFigure[] ColumnFigures
        {
            get => columnFigures;
            set
            {
                columnFigures = value;
                OnPropertyChanged();
            }
        }

        public BoardColumn() => ColumnFigures = new BaseFigure[8];

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}