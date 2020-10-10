using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.Core.Resources;
using BattleChess3.DefaultFigures;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace BattleChess3.UI.Services
{
    public class GameService : ViewModelBase
    {
        private readonly PlayerService _playerService = ServiceLocator.Current.GetInstance<PlayerService>();
        private readonly FigureService _figureService = ServiceLocator.Current.GetInstance<FigureService>();
        private readonly BoardService _boardService = ServiceLocator.Current.GetInstance<BoardService>();
        
        public RelayCommand<Tile> ClickedCommand { get; }
        public RelayCommand<Tile> MouseEnterCommand { get; }

        public GameService()
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
                _boardService.Board[i].Figure = CreateFigure(figureBlueprint);
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

        public void ClickedAtTile(Tile tile)
        {
            var selectedType = _boardService.SelectedTile.Figure.FigureType;
            if (tile.IsPossibleAttack)
            {
                selectedType.AttackAction(_boardService.SelectedTile, tile, _boardService.Board);
                if (selectedType.MovingAttack)
                    selectedType.MoveAction(_boardService.SelectedTile, tile, _boardService.Board);
                _boardService.SelectedTile = Tile.Invalid;
                _playerService.NextTurn();
            }
            else if (tile.IsPossibleMove)
            {
                selectedType.MoveAction(_boardService.SelectedTile, tile, _boardService.Board);
                _boardService.SelectedTile = Tile.Invalid;
                _playerService.NextTurn();
            }
            else if (tile.Figure.Owner.Id == _playerService.CurrentPlayer.Id)
                _boardService.SelectedTile = tile;
            else _boardService.SelectedTile = Tile.Invalid;
            SetPossibleActions(tile);
        }

        private void SetPossibleActions(Tile clickedTile)
        {
            foreach (Tile tile in _boardService.Board)
            {
                tile.IsPossibleAttack = false;
                tile.IsPossibleMove = false;
            }

            if (_playerService.CurrentPlayer.Id != _boardService.SelectedTile.Figure.Owner.Id)
                return;
            SetPossibleAttacks(clickedTile);
            SetPossibleMoves(clickedTile);
        }

        private void SetPossibleAttacks(Tile clickedTile)
        {
            var playerRelativePosition = clickedTile.Position.GetPlayerAbsolute(_playerService.CurrentPlayer.Id);
            Position[][] moveChains = clickedTile.Figure.FigureType.GetAttackChains(playerRelativePosition);
            
            foreach (Position[] moveChain in moveChains)
            foreach (Position position in moveChain)
            {
                Position absolute = clickedTile.Position + position.GetPlayerRelative(_playerService.CurrentPlayer.Id);
                if (!absolute.InBoard()) break;
                
                if (_boardService.Board[absolute].Figure.FigureType != Empty.Instance)
                {
                    _boardService.Board[absolute].IsPossibleAttack = clickedTile.Figure.CanKill(_boardService.Board[absolute].Figure);
                    break;
                }
            }
        }

        private void SetPossibleMoves(Tile clickedTile)
        {
            var playerRelativePosition = clickedTile.Position.GetPlayerAbsolute(_playerService.CurrentPlayer.Id);
            Position[][] moveChains = clickedTile.Figure.FigureType.GetMoveChains(playerRelativePosition);
            
            foreach (Position[] moveChain in moveChains)
            foreach (Position position in moveChain)
            {
                Position absolute = clickedTile.Position + position.GetPlayerRelative(_playerService.CurrentPlayer.Id);
                if (!absolute.InBoard()) break;
                
                if (_boardService.Board[absolute].Figure.FigureType == Empty.Instance)
                    _boardService.Board[absolute].IsPossibleMove = true;
                else break;
            }
        }

        public void MouseEnterTile(Tile tile)
            => _boardService.MouseOnTile = tile;
    }
}