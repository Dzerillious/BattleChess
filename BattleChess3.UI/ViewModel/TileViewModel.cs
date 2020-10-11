using System.ComponentModel;
using System.Runtime.CompilerServices;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.UI.Annotations;

namespace BattleChess3.UI.ViewModel
{
    public class TileViewModel : Tile, INotifyPropertyChanged
    {
        public override Position Position { get; }

        private bool _isMouseOver;
        public override bool IsMouseOver
        {
            get => _isMouseOver;
            set => Set(ref _isMouseOver, value);
        }

        private bool _isSelected;
        public override bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }

        private bool _isPossibleMove;
        public override bool IsPossibleMove
        {
            get => _isPossibleMove;
            set => Set(ref _isPossibleMove, value);
        }

        private bool _isPossibleAction;
        public override bool IsPossibleAttack
        {
            get => _isPossibleAction;
            set => Set(ref _isPossibleAction, value);
        }

        private Figure _figure = Figure.None;
        public override Figure Figure
        {
            get => _figure;
            set => Set(ref _figure, value);
        }

        public TileViewModel(Position position)
        {
            Position = position;
        }

        private void Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            var isSet = !field!.Equals(value);
            field = value;
            if (isSet) OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}