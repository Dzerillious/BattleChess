using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    private bool _menuTabSelected;
    public bool MenuTabSelected
    {
        get => _menuTabSelected;
        set
        {
            _ = value;
            SetSelectedTab(out _menuTabSelected);
        }
    }

    private bool _gameTabSelected;
    public bool GameTabSelected
    {
        get => _gameTabSelected;
        set
        {
            _ = value;
            SetSelectedTab(out _gameTabSelected);
        }
    }

    private bool _gameTabEnabled;
    public bool GameTabEnabled
    {
        get => _gameTabEnabled;
        set
        {
            _ = value;
            Set(ref _gameTabEnabled, value);
        }
    }

    private bool _optionsTabSelected;
    public bool OptionsTabSelected
    {
        get => _optionsTabSelected;
        set
        {
            _ = value;
            SetSelectedTab(out _optionsTabSelected);
        }
    }

    private bool _manualTabSelected;
    public bool ManualTabSelected
    {
        get => _manualTabSelected;
        set
        {
            _ = value;
            SetSelectedTab(out _manualTabSelected);
        }
    }

    public MapsViewModel MapsViewModel { get; }
    public BoardViewModel BoardViewModel { get; }

    public RelayCommand NewGameCommand { get; }
    public RelayCommand SaveGameCommand { get; }
    public RelayCommand DeleteGameCommand { get; }
    public RelayCommand SelectOptionsCommand { get; }
    public RelayCommand CloseApplicationCommand { get; }

    public MainWindowViewModel(
        MapsViewModel mapsViewModel,
        BoardViewModel boardViewModel)
    {
        MapsViewModel = mapsViewModel;
        BoardViewModel = boardViewModel;

        NewGameCommand = new RelayCommand(NewGame);
        SaveGameCommand = new RelayCommand(() => { });
        DeleteGameCommand = new RelayCommand(() => { });
        SelectOptionsCommand = new RelayCommand(() => OptionsTabSelected = true);
        CloseApplicationCommand = new RelayCommand(CloseApplication);
    }

    private void NewGame()
    {
        BoardViewModel.LoadMap(MapsViewModel.SelectedMap);
        GameTabEnabled = true;
        GameTabSelected = true;
    }

    private static void CloseApplication() => Application.Current.Shutdown();

    private void SetSelectedTab(out bool selectedTab)
    {
        _menuTabSelected = false;
        _gameTabSelected = false;
        _optionsTabSelected = false;
        _manualTabSelected = false;
        selectedTab = true;
        
        RaisePropertyChanged(nameof(MenuTabSelected));
        RaisePropertyChanged(nameof(GameTabSelected));
        RaisePropertyChanged(nameof(OptionsTabSelected));
        RaisePropertyChanged(nameof(ManualTabSelected));
    }
}
