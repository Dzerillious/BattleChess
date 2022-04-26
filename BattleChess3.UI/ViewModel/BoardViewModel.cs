using System;
using System.Linq;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.Core.Resources;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.UI.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.ViewModel;

public class BoardViewModel : ViewModelBase
{
    private readonly IFigureService _figureService;
    private readonly IPlayerService _playerService;

    private ITileViewModel _selectedTile = NoneTileViewModel.Instance;
    public ITileViewModel SelectedTile
    {
        get => _selectedTile;
        set
        {
            _selectedTile.IsSelected = false;
            Set(ref _selectedTile, value);
            value.IsSelected = true;
        }
    }

    private ITileViewModel _mouseOnTile = NoneTileViewModel.Instance;
    public ITileViewModel MouseOnTile
    {
        get => _mouseOnTile;
        set
        {
            _mouseOnTile.IsMouseOver = false;
            Set(ref _mouseOnTile, value);
            value.IsMouseOver = true;
        }
    }

    private int _boardWidth = 8;
    public int BoardWidth
    {
        get => _boardWidth;
        set => Set(ref _boardWidth, value);
    }

    public ITileViewModel[] Board { get; } = Enumerable.Range(0, Constants.BoardSize)
                                              .Select<int, ITileViewModel>(position => new TileViewModel(position))
                                              .ToArray();
    
    public RelayCommand<ITileViewModel> ClickedCommand { get; }
    public RelayCommand<ITileViewModel> MouseEnterCommand { get; }
    public RelayCommand<ITileViewModel> MouseExitCommand { get; }


    public event EventHandler<Position> RequestClickTile;
    public event EventHandler<MapBlueprint> RequestLoadMap;


    public BoardViewModel(
        IFigureService figureService,
        IPlayerService playerService)
    {
        _figureService = figureService;
        _playerService = playerService;

        ClickedCommand = new RelayCommand<ITileViewModel>(ClickedAtTile);
        MouseEnterCommand = new RelayCommand<ITileViewModel>(MouseEnterTile);
        MouseExitCommand = new RelayCommand<ITileViewModel>(MouseExitTile);
    }
    
    public void ManualLoadMap(MapBlueprint map)
    {
        AutomaticLoadMap(map);
        RequestLoadMap?.Invoke(this, map);
    }

    public void AutomaticLoadMap(MapBlueprint map)
    {
        AutomaticClickAtTile(NoneTileViewModel.Instance);
        _playerService.InitializePlayers(map.StartingPlayer);

        for (var i = 0; i < Constants.BoardSize; i++)
            CreateFigure(Board[i], map.Figures[i]);
    }

    public void CreateFigure(ITileViewModel tile, FigureBlueprint figureBlueprint)
    {
        tile.KillFigureWithoutMove(tile);

        var figureType = _figureService.GetFigureFromName(figureBlueprint.UnitName);
        var player = _playerService.GetPlayer(figureBlueprint.PlayerId);
        var figure = new Figure(player, figureType, figureBlueprint.Hp);
        player.Figures.Add(figure);
        tile.Figure = figure;
    }

    private void ClickedAtTile(ITileViewModel clickedTile)
    {
        AutomaticClickAtTile(clickedTile);
        RequestClickTile?.Invoke(this, clickedTile.Position);
    }

    public void AutomaticClickAtTile(ITileViewModel clickedTile)
    {

        if (clickedTile.IsPossibleAttack)
        {
            var clickedPovTile = clickedTile.GetPovTile(_playerService.CurrentPlayer);
            var selectedPovTile = SelectedTile.GetPovTile(_playerService.CurrentPlayer);
            var povBoard = GetPlayerPOVBoard(_playerService.CurrentPlayer, Board);
            SelectedTile.Figure.AttackAction(selectedPovTile, clickedPovTile, povBoard);
            SelectedTile = NoneTileViewModel.Instance;
            _playerService.NextTurn();
        }
        else if (clickedTile.IsPossibleMove)
        {
            var clickedPovTile = clickedTile.GetPovTile(_playerService.CurrentPlayer);
            var selectedPovTile = SelectedTile.GetPovTile(_playerService.CurrentPlayer);
            var povBoard = GetPlayerPOVBoard(_playerService.CurrentPlayer, Board);
            SelectedTile.Figure.MoveAction(selectedPovTile, clickedPovTile, povBoard);
            SelectedTile = NoneTileViewModel.Instance;
            _playerService.NextTurn();
        }
        else if (clickedTile.Figure.Owner == _playerService.CurrentPlayer)
        {
            SelectedTile = clickedTile;
        }
        else
        {
            SelectedTile = NoneTileViewModel.Instance;
        }

        SetPossibleActions(clickedTile);
    }

    private void SetPossibleActions(ITileViewModel clickedTile)
    {
        foreach (ITileViewModel tile in Board)
        {
            tile.IsPossibleAttack = false;
            tile.IsPossibleMove = false;
        }

        if (_playerService.CurrentPlayer != SelectedTile.Figure.Owner)
            return;

        SetPossibleAttacks(clickedTile);
        SetPossibleMoves(clickedTile);
    }

    private void SetPossibleAttacks(ITileViewModel clickedTile)
    {
        var povTile = clickedTile.GetPovTile(_playerService.CurrentPlayer);
        var povBoard = GetPlayerPOVBoard(_playerService.CurrentPlayer, Board);
        Position[][] attackChains = clickedTile.Figure.GetAttackChains(povTile.Position, povBoard);

        foreach (Position[] moveChain in attackChains)
        foreach (Position relativeAttack in moveChain)
        {
            Position boardAttack = (povTile.Position + relativeAttack).GetPlayerPOVPosition(_playerService.CurrentPlayer);
            if (!boardAttack.InBoard()) 
                break;

            var attackedTile = Board[boardAttack].GetPovTile(_playerService.CurrentPlayer);
            if (attackedTile.IsEmpty() ||
                attackedTile.IsWater())
                continue;

            Board[boardAttack].IsPossibleAttack = povTile.Figure.CanAttack(povTile, attackedTile, povBoard);
            break;
        }
    }

    private void SetPossibleMoves(ITileViewModel clickedTile)
    {
        var povTile = clickedTile.GetPovTile(_playerService.CurrentPlayer);
        var povBoard = GetPlayerPOVBoard(_playerService.CurrentPlayer, Board);
        Position[][] moveChains = clickedTile.Figure.GetMoveChains(povTile.Position, povBoard);
        
        foreach (Position[] moveChain in moveChains)
        foreach (Position relativeMove in moveChain)
        {
            Position boardMove = (povTile.Position + relativeMove).GetPlayerPOVPosition(_playerService.CurrentPlayer);
            if (!boardMove.InBoard()) 
                break;

            var targetTile = Board[boardMove].GetPovTile(_playerService.CurrentPlayer);
            if (povTile.Figure.CanMove(povTile, targetTile, povBoard))
                Board[boardMove].IsPossibleMove = true;
            else if (targetTile.IsWater())
                continue;
            else
                break;
        }
    }

    private ITile[] GetPlayerPOVBoard(Player player, ITile[] board)
    {
        var povBoard = new ITile[Constants.BoardSize];

        for (int i = 0; i < Constants.BoardLength; i++)
        for (int j = 0; j < Constants.BoardLength; j++)
        {
            var position = new Position(j, i);
            povBoard[position.GetPlayerPOVPosition(player)] = board[position];
        }

        return povBoard;
    }

    private void MouseEnterTile(ITileViewModel tile)
        => MouseOnTile = tile;

    private void MouseExitTile(ITileViewModel tile)
    {
        if (MouseOnTile == tile) MouseOnTile = NoneTileViewModel.Instance;
    }
}
