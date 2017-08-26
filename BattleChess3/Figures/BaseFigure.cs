using BattleChess3.Figures.FigureTypes;
using BattleChess3.Game;
using BattleChess3.Properties;

namespace BattleChess3.Figures
{
    /// <summary>
    /// Class for each figure
    /// </summary>
    public class BaseFigure
    {
        public Position Position { get; set; }
        public IFigure FigureType { get; set; }
        public int Hp { get; set; }
        public bool Clicked = false;
        public string Highlighted { get; set; }
        public string PicturePath { get; set; }
        private const double Bonus = 2;
        private const double AntiBonus = 0.5;
        public string Color;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public BaseFigure()
        {
            Hp = 100;
            Color = Resource.Neutral;
            Position = new Position();
            FigureType = new Nothing();
            Highlighted = Resource.NotHighlighted;
            PicturePath = Resource.PicturesPath + FigureType.PictureNeutralPath;
        }

        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="color"></param>
        /// <param name="position"></param>
        /// <param name="figureType"></param>
        public BaseFigure(string color, Position position, IFigure figureType)
        {
            Hp = 100;
            Color = color;
            Position = position;
            FigureType = figureType;
            Highlighted = Resource.NotHighlighted;
            if (Color == Resource.White)
            {
                PicturePath = Resource.PicturesPath + FigureType.PictureWhitePath;
            }
            else if (Color == Resource.Black)
            {
                PicturePath = Resource.PicturesPath + FigureType.PictureBlackPath;
            }
            else
            {
                PicturePath = Resource.PicturesPath + FigureType.PictureNeutralPath;
            }
        }

        /// <summary>
        /// Tries to play the position if it is your turn
        /// </summary>
        /// <param name="position"></param>
        public bool TryPlay(Position position)
        {
            if (Play.WhooseTurn != Color) return false;
            if (CanMove(Play.GetFigureAtPosition(position)))
            {
                Play.MoveFigureToPosition(Position, position);
                Position = position;
                return true;
            }
            if (CanAttack(position))
            {
                TryAttack(Play.GetFigureAtPosition(position));
                if (FigureType.MovingWhileAttacking)
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
        /// <param name="figure"></param>
        /// <returns></returns>
        public bool CanMove(BaseFigure figure) => figure.FigureType.UnitName == Resource.Nothing && FigureType.CanMove(Position, figure.Position);

        /// <summary>
        /// Checks if can attack enemy
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool CanAttack(Position position)
        {
            var enemy = Play.GetFigureAtPosition(position);
            if (FigureType.CanAttack(Position, position) && enemy.FigureType.Defence < FigureType.Attack)
            {
                if (FigureType.MovingWhileAttacking && FigureType.LongRanged)
                {
                    var remainingHp = enemy.RemainedHpOfAttacked(enemy);
                    return remainingHp <= 0;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tries to attack at certain position and return if attacked
        /// </summary>
        public bool TryAttack(BaseFigure enemy)
        {
            var remainingHp = enemy.RemainedHpOfAttacked(enemy);
            if (FigureType.MovingWhileAttacking && FigureType.LongRanged)
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
        public int RemainedHpOfAttacked(BaseFigure attackedUnit)
        {
            double bonus = 1;
            if (attackedUnit.FigureType.UnitType == FigureType.Bonus)
            {
                bonus = Bonus;
            }
            else if (attackedUnit.FigureType.UnitType == FigureType.AntiBonus)
            {
                bonus = AntiBonus;
            }
            return attackedUnit.Hp - (int)(attackedUnit.FigureType.Attack * bonus) - attackedUnit.FigureType.Defence;
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
