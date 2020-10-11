using System.Linq;
using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.Core.Resources;
using BattleChess3.DefaultFigures;
using BattleChess3.UI.Services;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.ViewModel
{
    public class BoardViewModel : ViewModelBase
    {
        private readonly FigureService _figureService = ServiceLocator.Current.GetInstance<FigureService>();
        private readonly PlayerService _playerService = ServiceLocator.Current.GetInstance<PlayerService>();
        
        public Tile[] Board { get; } = Enumerable.Range(0, Constants.BoardSize)
                                                 .Select<int, Tile>(position => new TileViewModel(position))
                                                 .ToArray();

        private Tile _selectedTile = Tile.None;
        public Tile SelectedTile
        {
            get => _selectedTile;
            set
            {
                _selectedTile.IsSelected = false;
                Set(ref _selectedTile, value);
                value.IsSelected = true;
            }
        }

        private Tile _mouseOnTile = Tile.None;
        public Tile MouseOnTile
        {
            get => _mouseOnTile;
            set
            {
                _mouseOnTile.IsMouseOver = false;
                Set(ref _mouseOnTile, value);
                value.IsMouseOver = true;
            }
        }
        
        public RelayCommand<Tile> ClickedCommand { get; }
        public RelayCommand<Tile> MouseEnterCommand { get; }
        

        public BoardViewModel()
        {
            ClickedCommand = new RelayCommand<Tile>(ClickedAtTile);
            MouseEnterCommand = new RelayCommand<Tile>(MouseEnterTile);
        }
        
        public void LoadMap(MapBlueprint map)
        {
            _playerService.InitializePlayers(map.PlayersCount, map.StartingPlayer);
            for (var i = 0; i < Constants.BoardSize; i++)
            {
                var figureBlueprint = map.Figures[i];
                Board[i].Figure = CreateFigure(figureBlueprint);
            }
        }

        private Figure CreateFigure(FigureBlueprint figureBlueprint)
        {
            var figureType = _figureService.GetFigureFromName(figureBlueprint.FigureName);
            var player = _playerService.GetPlayer(figureBlueprint.PlayerId);
            var figure = new Figure(player, figureType);
            player.Figures.Add(figure);
            return figure;
        }
        

        public void ClickedAtTile(Tile clickedTile)
        {
            var selectedType = SelectedTile.Figure.FigureType;
            if (clickedTile.IsPossibleAttack)
            {
                selectedType.AttackAction(SelectedTile, clickedTile, Board);
                if (selectedType.MovingAttack)
                    selectedType.MoveAction(SelectedTile, clickedTile, Board);
                SelectedTile = Tile.None;
                _playerService.NextTurn();
            }
            else if (clickedTile.IsPossibleMove)
            {
                selectedType.MoveAction(SelectedTile, clickedTile, Board);
                SelectedTile = Tile.None;
                _playerService.NextTurn();
            }
            else if (clickedTile.Figure.Owner == _playerService.CurrentPlayer)
                SelectedTile = clickedTile;
            else SelectedTile = Tile.None;
            SetPossibleActions(clickedTile);
        }

        private void SetPossibleActions(Tile clickedTile)
        {
            foreach (Tile tile in Board)
            {
                tile.IsPossibleAttack = false;
                tile.IsPossibleMove = false;
            }

            if (_playerService.CurrentPlayer != SelectedTile.Figure.Owner)
                return;
            SetPossibleAttacks(clickedTile);
            SetPossibleMoves(clickedTile);
        }

        private void SetPossibleAttacks(Tile clickedTile)
        {
            var playerPOVPosition = clickedTile.Position.GetPlayerPOVPosition(_playerService.CurrentPlayer);
            Position[][] attackChains = clickedTile.Figure.FigureType.GetAttackChains(playerPOVPosition);
            
            foreach (Position[] moveChain in attackChains)
            foreach (Position position in moveChain)
            {
                Position attackPosition = clickedTile.Position + position.GetPlayerPOVRelative(_playerService.CurrentPlayer);
                if (!attackPosition.InBoard()) break;

                var attackedTile = Board[attackPosition];
                if (attackedTile.Figure.FigureType == Empty.Instance) 
                    continue;
                attackedTile.IsPossibleAttack = clickedTile.Figure.CanKill(attackedTile.Figure);
                break;
            }
        }

        private void SetPossibleMoves(Tile clickedTile)
        {
            var playerPOVPosition = clickedTile.Position.GetPlayerPOVPosition(_playerService.CurrentPlayer);
            Position[][] moveChains = clickedTile.Figure.FigureType.GetMoveChains(playerPOVPosition);
            
            foreach (Position[] moveChain in moveChains)
            foreach (Position position in moveChain)
            {
                Position movePosition = clickedTile.Position + position.GetPlayerPOVRelative(_playerService.CurrentPlayer);
                if (!movePosition.InBoard()) break;
                
                var movedTile = Board[movePosition];
                if (movedTile.Figure.FigureType == Empty.Instance)
                    movedTile.IsPossibleMove = true;
                else break;
            }
        }

        public void MouseEnterTile(Tile tile)
            => MouseOnTile = tile;
    }
}