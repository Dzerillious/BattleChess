using System.Windows;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;
using BattleChess3.Game.Players;
using BattleChess3.Maps;
using BattleChess3.Multiplayer;
using BattleChess3.UI.Localization;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.ViewModel;

public sealed class MultiplayerViewModel : ViewModelBase
{
    private readonly BoardViewModel _boardViewModel;
    private readonly IMultiplayerService _multiplayerService;
    private readonly IPlayerService _playerService;

    private string _apiKey = CurrentLocalization.Instance["MultiplayerService_ApiKey"];

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

    public bool IsConnected => _multiplayerService.IsHost || _multiplayerService.IsGuest;
    public bool CanConnect => _multiplayerService is { IsHost: false, IsGuest: false };

    public string ApiKey
    {
        get => _apiKey;
        set => Set(ref _apiKey, value);
    }

    public RelayCommand HostCommand { get; }
    public RelayCommand JoinCommand { get; }
    public RelayCommand StopCommand { get; }
    public RelayCommand PasteKeyCommand { get; }

    private void SubscribeToEvents()
    {
        _multiplayerService.RequestClickTile += RemoteRequestedClickTile;
        _multiplayerService.RequestLoadMap += RemoteRequestedLoadMap;
        _multiplayerService.RequestDisplayMessage += RemoteRequestedDisplayMessage;
        _boardViewModel.RequestClickTile += LocalRequestClickTile;
        _boardViewModel.RequestLoadMap += LocalRequestLoadMap;
    }

    private void RemoteRequestedDisplayMessage(object? sender, string e)
    {
        Application.Current.Dispatcher.Invoke(() => MessageBox.Show(e));
    }

    private void LocalRequestLoadMap(object? sender, MapBlueprint e)
    {
        Application.Current.Dispatcher.Invoke(() => _multiplayerService.LoadMap(e));
    }

    private void LocalRequestClickTile(object? sender, Position e)
    {
        Application.Current.Dispatcher.Invoke(() => _multiplayerService.ClickOnPosition(e));
    }

    private void RemoteRequestedLoadMap(object? sender, MapBlueprint e)
    {
        _boardViewModel.AutomaticLoadMap(e);
    }

    private void RemoteRequestedClickTile(object? sender, Position e)
    {
        _boardViewModel.AutomaticClickAtTile(!e.IsInBoard()
            ? NoneTileViewModel.Instance
            : _boardViewModel.Tiles[e]);
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
            Figures = _boardViewModel.Tiles.Select(x => new FigureIdentifier
            {
                PlayerId = x.Figure.Owner.Id,
                UnitName = x.Figure.UnitName
            }).ToArray(),
            StartingPlayer = _playerService.CurrentPlayer.Id
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