using System.Linq;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.Core.Resources;
using BattleChess3.DefaultFigures.Utilities;
using BattleChess3.UI.Services;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.ViewModel;

public class BoardViewModel : ViewModelBase
{
    private readonly FigureService _figureService = ServiceLocator.Current.GetInstance<FigureService>();
    private readonly PlayerService _playerService = ServiceLocator.Current.GetInstance<PlayerService>();

    private ITile _selectedTile = NoneTile.Instance;
    public ITile SelectedTile
    {
        get => _selectedTile;
        set
        {
            _selectedTile.IsSelected = false;
            Set(ref _selectedTile, value);
            value.IsSelected = true;
        }
    }

    private ITile _mouseOnTile = NoneTile.Instance;
    public ITile MouseOnTile
    {
        get => _mouseOnTile;
        set
        {
            _mouseOnTile.IsMouseOver = false;
            Set(ref _mouseOnTile, value);
            value.IsMouseOver = true;
        }
    }
    
    public ITile[] Board { get; } = Enumerable.Range(0, Constants.BoardSize)
                                              .Select<int, ITile>(position => new TileViewModel(position))
                                              .ToArray();
    
    public RelayCommand<ITile> ClickedCommand { get; }
    public RelayCommand<ITile> MouseEnterCommand { get; }
    public RelayCommand<ITile> MouseExitCommand { get; }
    

    public BoardViewModel()
    {
        ClickedCommand = new RelayCommand<ITile>(ClickedAtTile);
        MouseEnterCommand = new RelayCommand<ITile>(MouseEnterTile);
        MouseExitCommand = new RelayCommand<ITile>(MouseExitTile);
    }
    
    public void LoadMap(MapBlueprint map)
    {
        ClickedAtTile(NoneTile.Instance);
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


    private void ClickedAtTile(ITile clickedTile)
    {
        var selectedType = SelectedTile.Figure.FigureType;
        if (clickedTile.IsPossibleAttack)
        {
            selectedType.AttackAction(SelectedTile, clickedTile, Board);
            if (selectedType.MovingAttack) selectedType.MoveAction(SelectedTile, clickedTile, Board);
            SelectedTile = NoneTile.Instance;
            _playerService.NextTurn();
        }
        else if (clickedTile.IsPossibleMove)
        {
            selectedType.MoveAction(SelectedTile, clickedTile, Board);
            SelectedTile = NoneTile.Instance;
            _playerService.NextTurn();
        }
        else if (clickedTile.Figure.Owner == _playerService.CurrentPlayer)
            SelectedTile = clickedTile;
        else SelectedTile = NoneTile.Instance;
        SetPossibleActions(clickedTile);
    }

    private void SetPossibleActions(ITile clickedTile)
    {
        foreach (ITile tile in Board)
        {
            tile.IsPossibleAttack = false;
            tile.IsPossibleMove = false;
        }

        if (_playerService.CurrentPlayer != SelectedTile.Figure.Owner)
            return;
        SetPossibleAttacks(clickedTile);
        SetPossibleMoves(clickedTile);
    }

    private void SetPossibleAttacks(ITile clickedTile)
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

    private void SetPossibleMoves(ITile clickedTile)
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

    private void MouseEnterTile(ITile tile)
        => MouseOnTile = tile;

    private void MouseExitTile(ITile tile)
    {
        if (MouseOnTile == tile) MouseOnTile = NoneTile.Instance;
    }
}
