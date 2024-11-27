using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;
using BattleChess3.Game.Players;
using BattleChess3.Maps;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.ViewModel;

public sealed class BoardViewModel : ViewModelBase
{
    private readonly IPlayerService _playerService;
    private readonly IMapLoader _mapLoader;
    private readonly IFigureCreator _figureCreator;

    private TileViewModel _mouseOnTile = NoneTileViewModel.Instance;
    private TileViewModel _selectedTile = NoneTileViewModel.Instance;

    public BoardViewModel(
        IPlayerService playerService,
        IMapLoader mapLoader,
        IFigureCreator figureCreator)
    {
        _playerService = playerService;
        _mapLoader = mapLoader;
        _figureCreator = figureCreator;

        ClickedCommand = new RelayCommand<TileViewModel>(ClickedAtTile);
        MouseEnterCommand = new RelayCommand<TileViewModel>(MouseEnterTile);
        MouseExitCommand = new RelayCommand<TileViewModel>(MouseExitTile);

        Tiles = Enumerable.Range(0, IBoard.TilesCount)
            .Select<int, TileViewModel>(position => new TileViewModel(position))
            .ToArray();
        Board = new Board(Tiles.Cast<ITile>().ToArray());
    }

    public TileViewModel SelectedTile
    {
        get => _selectedTile;
        private set
        {
            _selectedTile.IsSelected = false;
            Set(ref _selectedTile, value);
            RaisePropertyChanged(nameof(InfoTile));
            value.IsSelected = true;
        }
    }

    public TileViewModel MouseOnTile
    {
        get => _mouseOnTile;
        private set
        {
            _mouseOnTile.IsMouseOver = false;
            Set(ref _mouseOnTile, value);
            
            if (_selectedTile.Equals(NoneTileViewModel.Instance))
            {                
                ClearPossibleActions();
                SetPossibleActions(value);
            }
            
            RaisePropertyChanged(nameof(InfoTile));
            value.IsMouseOver = true;
        }
    }

    public TileViewModel InfoTile =>
        SelectedTile is not NoneTileViewModel
            ? SelectedTile
            : MouseOnTile;

    public int BoardWidth
    {
        get => IBoard.Length;
    }

    public IBoard Board { get; }
    public TileViewModel[] Tiles { get; }

    public RelayCommand<TileViewModel> ClickedCommand { get; }
    public RelayCommand<TileViewModel> MouseEnterCommand { get; }
    public RelayCommand<TileViewModel> MouseExitCommand { get; }


    public event EventHandler<Position>? RequestClickTile;
    public event EventHandler<MapBlueprint>? RequestLoadMap;

    public void ManualLoadMap(MapBlueprint map)
    {
        _mapLoader.LoadMap(Board, map);
        RequestLoadMap?.Invoke(this, map);
    }

    public void AutomaticLoadMap(MapBlueprint map)
    {
        _mapLoader.LoadMap(Board, map);
    }

    public void CreateFigure(ITile tile, FigureIdentifier figureIdentifier)
    {
        tile.Figure = _figureCreator.CreateFigure(figureIdentifier);
    }

    private void ClickedAtTile(TileViewModel clickedTile)
    {
        AutomaticClickAtTile(clickedTile);
        RequestClickTile?.Invoke(this, clickedTile.Position);
    }

    public void AutomaticClickAtTile(TileViewModel clickedTile)
    {
        if (clickedTile.PossibleAction.ActionType != FigureActionTypes.None)
        {
            clickedTile.PossibleAction.Action.Invoke();
            SelectedTile = NoneTileViewModel.Instance;
            _playerService.NextTurn();
        }
        else if (clickedTile.Figure.Owner.Equals(_playerService.CurrentPlayer))
        {
            SelectedTile = clickedTile;
        }
        else
        {
            SelectedTile = NoneTileViewModel.Instance;
        }

        ClearPossibleActions();
        SetPossibleActions(clickedTile);
    }


    private void ClearPossibleActions()
    {
        foreach (var tile in Tiles)
        {
            tile.PossibleAction = FigureAction.None;
        }
    }

    private void SetPossibleActions(ITile clickedTile)
    {
        if (!_playerService.CurrentPlayer.Equals(clickedTile.Figure.Owner))
            return;
        
        var povBoard = GetPlayerPOVBoard(clickedTile.Figure.Owner, Tiles);
        var povClickedTile = clickedTile.GetPovTile(clickedTile.Figure.Owner);
        var possibleActions = clickedTile.Figure.GetPossibleActions(povClickedTile, povBoard);
        
        foreach (var possibleAction in possibleActions)
        {
            Tiles[possibleAction.TargetPosition].PossibleAction = possibleAction;
        }
    }

    private static IBoard GetPlayerPOVBoard(Player player, IReadOnlyList<ITile> board)
    {
        var povBoard = new ITile[IBoard.TilesCount];
        var absoluteBoard = board.Select(x => x.GetPovTile(player)).ToArray();

        for (var i = 0; i < IBoard.Length; i++)
        for (var j = 0; j < IBoard.Length; j++)
        {
            var position = new Position(j, i);
            povBoard[position.GetPlayerPOVPosition(player)] = absoluteBoard[position];
        }

        return new Board(povBoard);
    }

    private void MouseEnterTile(TileViewModel tile)
    {
        MouseOnTile = tile;
    }

    private void MouseExitTile(TileViewModel tile)
    {
        if (MouseOnTile == tile)
        {
            MouseOnTile = NoneTileViewModel.Instance;
        }
    }
}