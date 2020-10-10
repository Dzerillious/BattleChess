using BattleChess3.Core.Models;
using GalaSoft.MvvmLight;

namespace BattleChess3.UI.Services
{
    public class GameService : ViewModelBase
    {
        private readonly PlayerService _playerService = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlayerService>();
        private readonly FigureService _figureService = CommonServiceLocator.ServiceLocator.Current.GetInstance<FigureService>();
        private readonly BoardService _boardService = CommonServiceLocator.ServiceLocator.Current.GetInstance<BoardService>();

        public void LoadMap(MapBlueprint map)
        {
            _playerService.InitializePlayers(map.PlayersCount, map.StartingPlayer);
            for (var i = 0; i < 64; i++)
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
        
        // /// <summary>
        // /// Tries to play the position if it is your turn
        // /// </summary>
        // public bool TryPlay(Figure me, Position position)
        // {
        //     if (WhooseTurn != me.Owner) return false;
        //     var enemy = GetFigureAtPosition(position);
        //     if (me.CanMove(enemy, GetFigureAtPosition))
        //     {
        //         MoveFigureToPosition(me.Position, position);
        //         me.Position = position;
        //         return true;
        //     }
        //     if (enemy.PlayerNumber != me.Owner && me.CanAttack(enemy, GetFigureAtPosition))
        //     {
        //         if (me.FigureType.MovingWhileAttacking && TryAttack(me, GetFigureAtPosition(position)))
        //         {
        //             MoveFigureToPosition(me.Position, position);
        //             me.Position = position;
        //         }
        //         return true;
        //     }
        //     return false;
        // }
        //
        // /// <summary>
        // /// Tries to attack at certain position and return if attacked
        // /// </summary>
        // public bool TryAttack(Figure me, Figure enemy)
        // {
        //     var remainingHp = enemy.RemainingHpOfAttacked(me);
        //     if (me.FigureType.MovingWhileAttacking)
        //     {
        //         if (remainingHp > 0) return false;
        //         AttackPattern(enemy.Position, me);
        //         return true;
        //     }
        //     AttackPattern(enemy.Position, me);
        //     return true;
        // }
        //
        // /// <summary>
        // /// Attacks each figure of pattern
        // /// </summary>
        // public void AttackPattern(Position attackedPosition, Figure me)
        // {
        //     foreach (var position in me.FigureType.AttackPattern)
        //         AttackFigure(me, GetFigureAtPosition(position.AddPositions(attackedPosition)));
        // }
        //
        // /// <summary>
        // /// Attacks figure if Hp is lesser 0 figure dies
        // /// </summary>
        // public void AttackFigure(Figure attacking, Figure attacked)
        // {
        //     attacked.Hp = attacked.RemainingHpOfAttacked(attacking);
        //     if (attacked.Hp <= 0) KillFigure(attacked);
        // }
        //
        public void ClickedAtTile(Tile tile)
        {
            // if (tile.IsPossibleAction)
            //     _boardService.SelectedTile.DoAction(tile);
            // else if (tile.IsPossibleMove)
            //     _boardService.SelectedTile.Move(tile);
            // else _boardService.SelectedTile = tile;
            // SetPossibleActions();
            
            // if (_boardService.SelectedTile.Position == Position.Invalid)
            // {
            //     _boardService.SelectedTile = tile;
            // }
            // else
            // {
            //     _playedPosition = position;
            //     PlayTurn();
            // }
            // HighlightTiles();
        }
        
        public void MouseEnterTile(Tile tile)
            => _boardService.MouseOnTile = tile;
        
        //
        // public void PlayTurn()
        // {
        //     var figure = SelectedTile.Figure;
        //     if (TryPlay(figure, _playedPosition) == false)
        //     {
        //         SelectedTile.SetSelected(_playedPosition);
        //         _playedPosition = Position.Invalid;
        //     }
        //     else
        //     {
        //         WhooseTurn = WhooseTurn == 1 ? 2 : 1;
        //         SelectedTile = new SelectedTile();
        //         _playedPosition = Position.Invalid;
        //     }
        // }
    }
}