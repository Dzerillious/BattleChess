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
        
        public bool IsHovered { get; set; }
        public bool IsSelected { get; set; }
        public bool IsDangered { get; set; }
        
        private Position _position = Position.Invalid;
        public override Position Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }
        
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

        public TileViewModel()
        {
            ClickedCommand = new RelayCommand(OnClicked);
            ServiceLocator.Current.GetInstance<BoardService>().Board[_position] = this;
        }

        private void OnClicked() => _gameService.ClickedAtTile(this);

        public event PropertyChangedEventHandler? PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}