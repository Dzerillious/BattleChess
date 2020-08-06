using System.Windows.Documents;
using BattleChess3.Core;

namespace BattleChess3.UI.ViewModel
{
    public class TileViewModel
    {
        public bool IsHovered { get; set; }
        public bool IsSelected { get; set; }
        public bool IsDangered { get; set; }
        public Figure Figure { get; set; }
    
        /// <summary>
        /// Tries to play the position if it is your turn
        /// </summary>
        public static bool TryPlay(Figure me, Position position)
        {
            if (WhooseTurn != me.Owner) return false;
            var enemy = GetFigureAtPosition(position);
            if (me.CanMove(enemy, GetFigureAtPosition))
            {
                MoveFigureToPosition(me.Position, position);
                me.Position = position;
                return true;
            }
            if (enemy.PlayerNumber != me.Owner && me.CanAttack(enemy, GetFigureAtPosition))
            {
                if (me.FigureType.MovingWhileAttacking && TryAttack(me, GetFigureAtPosition(position)))
                {
                    MoveFigureToPosition(me.Position, position);
                    me.Position = position;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tries to attack at certain position and return if attacked
        /// </summary>
        public static bool TryAttack(Figure me, Figure enemy)
        {
            var remainingHp = enemy.RemainingHpOfAttacked(me);
            if (me.FigureType.MovingWhileAttacking)
            {
                if (remainingHp > 0) return false;
                AttackPattern(enemy.Position, me);
                return true;
            }
            AttackPattern(enemy.Position, me);
            return true;
        }

        /// <summary>
        /// Attacks each figure of pattern
        /// </summary>
        public static void AttackPattern(Position attackedPosition, Figure me)
        {
            foreach (var position in me.FigureType.AttackPattern)
                AttackFigure(me, GetFigureAtPosition(position.AddPositions(attackedPosition)));
        }

        /// <summary>
        /// Attacks figure if Hp is lesser 0 figure dies
        /// </summary>
        public static void AttackFigure(Figure attacking, Figure attacked)
        {
            attacked.Hp = attacked.RemainingHpOfAttacked(attacking);
            if (attacked.Hp <= 0) KillFigure(attacked);
        }
        
        public static void ClickedAtPosition(Position position)
        {
            if (SelectedTile.Position == Position.Invalid)
            {
                SelectedTile.SetSelected(position);
            }
            else
            {
                _playedPosition = position;
                PlayTurn();
            }
            SetBindedBoard();
            HighlightTiles();
        }

        public static void PlayTurn()
        {
            var figure = SelectedTile.Figure;
            if (TryPlay(figure, _playedPosition) == false)
            {
                SelectedTile.SetSelected(_playedPosition);
                _playedPosition = Position.Invalid;
            }
            else
            {
                WhooseTurn = WhooseTurn == 1 ? 2 : 1;
                SelectedTile = new SelectedTile();
                _playedPosition = Position.Invalid;
            }
        }
    }
}