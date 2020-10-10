using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;
using BattleChess3.Core.Resources;
using BattleChess3.DefaultFigures;
using BattleChess3.DefaultFigures.Utilities;
using CommonServiceLocator;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.Services
{
    public class GameService : ViewModelBase
    {
        private readonly PlayerService _playerService = ServiceLocator.Current.GetInstance<PlayerService>();
        private readonly FigureService _figureService = ServiceLocator.Current.GetInstance<FigureService>();
        private readonly BoardService _boardService = ServiceLocator.Current.GetInstance<BoardService>();

        public void LoadMap(MapBlueprint map)
        {
            _playerService.InitializePlayers(map.PlayersCount, map.StartingPlayer);
            for (var i = 0; i < Constants.BoardSize; i++)
            {
                var figureBlueprint = map.Blueprint[i];
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
            if (tile.IsPossibleAttack)
            {
                _boardService.SelectedTile.Figure.FigureType.AttackAction(_boardService.SelectedTile, tile, _boardService.Board);
                if (_boardService.SelectedTile.Figure.FigureType.MovingAttack)
                    _boardService.SelectedTile.Figure.FigureType.MoveAction(_boardService.SelectedTile, tile, _boardService.Board);
                _boardService.SelectedTile = Tile.Invalid;
                _playerService.NextTurn();
            }
            else if (tile.IsPossibleMove)
            {
                _boardService.SelectedTile.Figure.FigureType.MoveAction(_boardService.SelectedTile, tile, _boardService.Board);
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
            {
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
        }

        private void SetPossibleMoves(Tile clickedTile)
        {
            var playerRelativePosition = clickedTile.Position.GetPlayerAbsolute(_playerService.CurrentPlayer.Id);
            Position[][] moveChains = clickedTile.Figure.FigureType.GetMoveChains(playerRelativePosition);
            foreach (Position[] moveChain in moveChains)
            {
                foreach (Position position in moveChain)
                {
                    Position absolute = clickedTile.Position + position.GetPlayerRelative(_playerService.CurrentPlayer.Id);
                    if (!absolute.InBoard()) break;
                    if (_boardService.Board[absolute].Figure.FigureType == Empty.Instance)
                        _boardService.Board[absolute].IsPossibleMove = true;
                    else break;
                }
            }
        }

        public void MouseEnterTile(Tile tile)
            => _boardService.MouseOnTile = tile;
    }
}