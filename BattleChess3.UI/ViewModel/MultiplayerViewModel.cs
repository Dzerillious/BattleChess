
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.UI.Services;
using BattleChess3.UI.Utilities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System.Windows;

namespace BattleChess3.UI.ViewModel;

public class MultiplayerViewModel : ViewModelBase
{
    private readonly BoardViewModel _boardViewModel;
    private readonly IMultiplayerService _multiplayerService;
    private readonly IPlayerService _playerService;

    public bool IsConnected => _multiplayerService.IsHost || _multiplayerService.IsGuest;
    public bool CanConnect => !_multiplayerService.IsHost && !_multiplayerService.IsGuest;

    private string _apiKey = CurrentLocalization.Instance["MultiplayerService_ApiKey"];
    public string ApiKey
    {
        get => _apiKey;
        set => Set(ref _apiKey, value);
    }

    public RelayCommand HostCommand { get; private set; }
    public RelayCommand JoinCommand { get; private set; }
    public RelayCommand StopCommand { get; private set; }
    public RelayCommand PasteKeyCommand { get; private set; }

    public MultiplayerViewModel(
        BoardViewModel boardViewModel,
        IMultiplayerService multiplayerService,
        IPlayerService playerService)
    {
        _boardViewModel = boardViewModel;
        _multiplayerService = multiplayerService;
        _playerService = playerService;

        HostCommand = new RelayCommand(HostGame, CanConnect);
        JoinCommand = new RelayCommand(JoinGame, IsConnected);
        StopCommand = new RelayCommand(StopMultiplayer, CanConnect);
        PasteKeyCommand = new RelayCommand(PasteKey, CanConnect);

        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        _multiplayerService.RequestClickTile += RemoteRequestedClickTile;
        _multiplayerService.RequestLoadMap += RemoteRequestedLoadMap;
        _boardViewModel.RequestClickTile += LocalRequestClickTile;
        _boardViewModel.RequestLoadMap += LocalRequestLoadMap;
    }

    private void LocalRequestLoadMap(object? sender, MapBlueprint e)
    {
        _multiplayerService.LoadMap(e);
    }

    private void LocalRequestClickTile(object? sender, Position e)
    {
        _multiplayerService.ClickOnPosition(e);
    }

    private void RemoteRequestedLoadMap(object? sender, MapBlueprint e)
    {
        _boardViewModel.AutomaticLoadMap(e);
    }

    private void RemoteRequestedClickTile(object? sender, Position e)
    {
        if (!e.InBoard())
            _boardViewModel.AutomaticClickAtTile(NoneTileViewModel.Instance);
        else
            _boardViewModel.AutomaticClickAtTile(_boardViewModel.Board[e]);
    }

    public void SetKey(string key)
    {
        ApiKey = key;
        RaiseCanExecuteChanged();
    }

    private void PasteKey()
    {
        ApiKey = Clipboard.GetText();
        RaiseCanExecuteChanged();
    }

    private void StopMultiplayer()
    {
        _multiplayerService.Stop();
        RaiseCanExecuteChanged();
    }

    private void JoinGame()
    {
        _multiplayerService.Join(_apiKey);
        RaiseCanExecuteChanged();
    }

    private void HostGame()
    {
        var map = new MapBlueprint
        {
            Figures = _boardViewModel.Board.Select(x => new FigureBlueprint
            {
                Hp = x.Figure.Hp,
                PlayerId = x.Figure.Owner.Id,
                UnitName = x.Figure.UnitName
            }).ToArray(),
            StartingPlayer = _playerService.CurrentPlayer.Id,
        };

        _multiplayerService.Host(_apiKey, map, _boardViewModel.SelectedTile.Position);
        RaiseCanExecuteChanged();
    }

    private void RaiseCanExecuteChanged()
    {
        HostCommand.RaiseCanExecuteChanged();
        JoinCommand.RaiseCanExecuteChanged();
        StopCommand.RaiseCanExecuteChanged();
        PasteKeyCommand.RaiseCanExecuteChanged();

        RaisePropertyChanged(nameof(IsConnected));
        RaisePropertyChanged(nameof(CanConnect));
    }
}
