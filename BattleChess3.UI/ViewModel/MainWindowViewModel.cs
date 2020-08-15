using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _menuTabSelected;
        public bool MenuTabSelected
        {
            get => _menuTabSelected;
            set => SetSelectedTab(out _menuTabSelected);
        }

        private bool _gameTabSelected;
        public bool GameTabSelected
        {
            get => _gameTabSelected;
            set => SetSelectedTab(out _gameTabSelected);
        }
        
        private bool _optionsTabSelected;
        public bool OptionsTabSelected
        {
            get => _optionsTabSelected;
            set => SetSelectedTab(out _optionsTabSelected);
        }
        
        private bool _manualTabSelected;
        public bool ManualTabSelected
        {
            get => _manualTabSelected;
            set => SetSelectedTab(out _manualTabSelected);
        }

        public RelayCommand NewGameCommand { get; private set; }
        public RelayCommand SaveGameCommand { get; private set; }
        public RelayCommand DeleteGameCommand { get; private set; }
        public RelayCommand SelectOptionsCommand { get; private set; }
        public RelayCommand CloseApplicationCommand { get; private set; }

        public MainWindowViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            // NewGameCommand = new RelayCommand();
            SelectOptionsCommand = new RelayCommand(() => OptionsTabSelected = true);
            CloseApplicationCommand = new RelayCommand(CloseApplication);
        }

        private void CloseApplication() => Application.Current.Shutdown();

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
}