using System.ComponentModel;
using System.Runtime.CompilerServices;
using BattleChess3.Core.Models;
using BattleChess3.UI.Services;
using BattleChess3.UI.Utilities;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.ViewModel
{
    public class TileViewModel : Tile, INotifyPropertyChanged
    {
        private readonly GameService _gameService = ServiceLocator.Current.GetInstance<GameService>();

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
        public override bool IsPossibleAction
        {
            get => _isPossibleAction;
            set => Set(ref _isPossibleAction, value);
        }

        public override Position Position { get; }

        private Figure _figure = FigureHelper.Empty;
        public override Figure Figure
        {
            get => _figure;
            set
            {
                _figure = value;
                OnPropertyChanged();
            }
        }
        
        public RelayCommand ClickedCommand { get; private set; }
        public RelayCommand MouseEnterCommand { get; private set; }

        public TileViewModel(Position position)
        {
            Position = position;
            ClickedCommand = new RelayCommand(() => _gameService.ClickedAtTile(this));
            MouseEnterCommand = new RelayCommand(() => _gameService.MouseEnterTile(this));
        }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            var isSet = !field.Equals(value);
            field = value;
            if (isSet) OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}