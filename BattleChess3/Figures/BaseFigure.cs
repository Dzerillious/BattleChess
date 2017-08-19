using BattleChess3.Game;

namespace BattleChess3.Figures
{
    /// <summary>
    /// Class for each figure
    /// </summary>
    public class BaseFigure
    {
        private const double Bonus = 2;
        private const double AntiBonus = 0.5;
        public string Color;
        public Position Position;
        public IFigure Figure;
        public int Hp = 100;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="color"></param>
        /// <param name="position"></param>
        /// <param name="figure"></param>
        public BaseFigure(string color, Position position, IFigure figure)
        {
            Color = color;
            Position = position;
            Figure = figure;
        }

        /// <summary>
        /// Tries to play the position if it is your turn
        /// </summary>
        /// <param name="position"></param>
        public bool TryPlay(Position position)
        {
            if (Play.WhooseTurn != Color) return false;
            if (CanMove(position))
            {
                Play.MoveFigureToPosition(Position, position);
                Position = position;
                return true;
            }
            if (CanAttack(position))
            {
                Attack(Play.GetFigureAtPosition(position));
                if (Figure.MovingWhileAttacking)
                {
                    Play.MoveFigureToPosition(Position, position);
                    Position = position;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if can move at position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool CanMove(Position position) => Play.GetFigureAtPosition(position) == null && Figure.CanMove(Position, position);

        /// <summary>
        /// Checks if can attack enemy
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool CanAttack(Position position)
        {
            var enemy = Play.GetFigureAtPosition(position);
            if (Figure.CanAttack(Position, position) && enemy.Figure.Defence < Figure.Attack)
            {
                if (Figure.MovingWhileAttacking && Figure.LongRanged)
                {
                    var remainingHp = enemy.AttackUnit(enemy);
                    return remainingHp <= 0;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Atack at certain position and return if attacked
        /// </summary>
        public bool Attack(BaseFigure enemy)
        {
            var remainingHp = enemy.AttackUnit(enemy);
            if (Figure.MovingWhileAttacking && Figure.LongRanged)
            {
                if (remainingHp > 0) return false;
                enemy.Die();
                Play.MoveFigureToPosition(Position, enemy.Position);
                return true;
            }
            if (remainingHp <= 0)
            {
                enemy.Die();
            }
            else
            {
                enemy.Hp = remainingHp;
            }
            return true;
        }

        /// <summary>
        /// Returnes remaining hp of attacked unit
        /// </summary>
        /// <param name="attackedUnit"></param>
        public int AttackUnit(BaseFigure attackedUnit)
        {
            double bonus = 1;
            if (attackedUnit.Figure.UnitType == Figure.Bonus)
            {
                bonus = Bonus;
            }
            else if (attackedUnit.Figure.UnitType == Figure.AntiBonus)
            {
                bonus = AntiBonus;
            }
            return attackedUnit.Hp - (int)(attackedUnit.Figure.Attack * bonus) - attackedUnit.Figure.Defence;
        }

        /// <summary>
        /// Kills unit and empties his field
        /// </summary>
        public void Die()
        {
            Play.KillFigureAtPosition(Position);
            if (Play.WhitePlayer.Color == Color)
            {
                Play.WhitePlayer.KillFigure(this);
            }
            else
            {
                Play.BlackPlayer.KillFigure(this);
            }
        }
    }
}
