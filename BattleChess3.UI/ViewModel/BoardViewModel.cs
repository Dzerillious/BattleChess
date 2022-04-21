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
        var povPosition = clickedTile.Position.GetPlayerPOVPosition(_playerService.CurrentPlayer);
        var povBoard = GetPlayerPOVBoard(_playerService.CurrentPlayer, Board);
        Position[][] attackChains = clickedTile.Figure.FigureType.GetAttackChains(povPosition, povBoard);

        foreach (Position[] moveChain in attackChains)
        foreach (Position relativeAttack in moveChain)
        {
            Position povAttack = (povPosition + relativeAttack).GetPlayerPOVPosition(_playerService.CurrentPlayer);
            if (!povAttack.InBoard()) 
                break;

            var attackedTile = Board[povAttack];
            if (attackedTile.Figure.FigureType.IsEmpty())
                continue;

            attackedTile.IsPossibleAttack = clickedTile.Figure.CanAttack(attackedTile.Figure);
            break;
        }
    }

    private void SetPossibleMoves(ITileViewModel clickedTile)
    {
        var povPosition = clickedTile.Position.GetPlayerPOVPosition(_playerService.CurrentPlayer);
        var povBoard = GetPlayerPOVBoard(_playerService.CurrentPlayer, Board);
        Position[][] moveChains = clickedTile.Figure.FigureType.GetMoveChains(povPosition, povBoard);
        
        foreach (Position[] moveChain in moveChains)
        foreach (Position relativeMove in moveChain)
        {
            Position povMove = (povPosition + relativeMove).GetPlayerPOVPosition(_playerService.CurrentPlayer);
            if (!povMove.InBoard()) 
                break;

            if (Board[povMove].Figure.FigureType.IsEmpty())
                Board[povMove].IsPossibleMove = true;
            else 
                break;
        }
    }

    private ITile[] GetPlayerPOVBoard(Player player, ITile[] board)
    {
        var povBoard = new ITile[64];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                var position = new Position(j, i);
                povBoard[position.GetPlayerPOVPosition(player)] = board[position];
            }
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
