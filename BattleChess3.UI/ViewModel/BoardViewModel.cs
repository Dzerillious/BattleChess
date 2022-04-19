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
    
    public ITileViewModel[] Board { get; } = Enumerable.Range(0, Constants.BoardSize)
                                              .Select<int, ITileViewModel>(position => new TileViewModel(position))
                                              .ToArray();
    
    public RelayCommand<ITileViewModel> ClickedCommand { get; }
    public RelayCommand<ITileViewModel> MouseEnterCommand { get; }
    public RelayCommand<ITileViewModel> MouseExitCommand { get; }
    

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
    
    public void LoadMap(MapBlueprint map)
    {
        ClickedAtTile(NoneTileViewModel.Instance);
        _playerService.InitializePlayers(map.PlayersCount, map.StartingPlayer);
        for (var i = 0; i < Constants.BoardSize; i++)
        {
            var figureBlueprint = map.Figures[i];
            Board[i].Figure = CreateFigure(figureBlueprint);
        }
    }

    private Figure CreateFigure(FigureBlueprint figureBlueprint)
    {
        var figureType = _figureService.GetFigureFromName(figureBlueprint.UnitName);
        var player = _playerService.GetPlayer(figureBlueprint.PlayerId);
        var figure = new Figure(player, figureType, figureBlueprint.Hp);
        player.Figures.Add(figure);
        return figure;
    }


    private void ClickedAtTile(ITileViewModel clickedTile)
    {
        var selectedType = SelectedTile.Figure.FigureType;
        if (clickedTile.IsPossibleAttack)
        {
            selectedType.AttackAction(SelectedTile, clickedTile, Board);
            if (selectedType.MovingAttack) selectedType.MoveAction(SelectedTile, clickedTile, Board);
            SelectedTile = NoneTileViewModel.Instance;
            _playerService.NextTurn();
        }
        else if (clickedTile.IsPossibleMove)
        {
            selectedType.MoveAction(SelectedTile, clickedTile, Board);
            SelectedTile = NoneTileViewModel.Instance;
            _playerService.NextTurn();
        }
        else if (clickedTile.Figure.Owner == _playerService.CurrentPlayer)
            SelectedTile = clickedTile;
        else SelectedTile = NoneTileViewModel.Instance;
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
        var playerPOVPosition = clickedTile.Position.GetPlayerPOVPosition(_playerService.CurrentPlayer);
        Position[][] attackChains = clickedTile.Figure.FigureType.GetAttackChains(playerPOVPosition);
        
        foreach (Position[] moveChain in attackChains)
        foreach (Position position in moveChain)
        {
            Position attackPosition = clickedTile.Position + position.GetPlayerPOVRelative(_playerService.CurrentPlayer);
            if (!attackPosition.InBoard()) break;

            var attackedTile = Board[attackPosition];
            if (attackedTile.Figure.FigureType.IsEmpty()) 
                continue;
            attackedTile.IsPossibleAttack = clickedTile.Figure.CanKill(attackedTile.Figure);
            break;
        }
    }

    private void SetPossibleMoves(ITileViewModel clickedTile)
    {
        var playerPOVPosition = clickedTile.Position.GetPlayerPOVPosition(_playerService.CurrentPlayer);
        Position[][] moveChains = clickedTile.Figure.FigureType.GetMoveChains(playerPOVPosition);
        
        foreach (Position[] moveChain in moveChains)
        foreach (Position position in moveChain)
        {
            Position movePosition = clickedTile.Position + position.GetPlayerPOVRelative(_playerService.CurrentPlayer);
            if (!movePosition.InBoard()) break;

            if (Board[movePosition].Figure.FigureType.IsEmpty())
                Board[movePosition].IsPossibleMove = true;
            else break;
        }
    }

    private void MouseEnterTile(ITileViewModel tile)
        => MouseOnTile = tile;

    private void MouseExitTile(ITileViewModel tile)
    {
        if (MouseOnTile == tile) MouseOnTile = NoneTileViewModel.Instance;
    }
}
