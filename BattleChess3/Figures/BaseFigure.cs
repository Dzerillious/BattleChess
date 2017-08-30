using System.IO;
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
        /// Create empty
        /// </summary>
        public BaseFigure()
        {
            Hp = 100;
            Color = Resource.Neutral;
            Position = new Position();
            FigureType = new Nothing();
            Highlighted = StaticResources.NotHighlighted;
            PicturePath = Directory.GetCurrentDirectory() + Resource.PicturesPath + FigureType.PictureNeutralPath;
        }
        
        /// <summary>
        /// Create Nothing at position
        /// </summary>
        public BaseFigure(Position position)
        {
            Hp = 100;
            Color = Resource.Neutral;
            Position = position;
            FigureType = new Nothing();
            Highlighted = StaticResources.NotHighlighted;
            PicturePath = Directory.GetCurrentDirectory() + Resource.PicturesPath + FigureType.PictureNeutralPath;
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
            Highlighted = StaticResources.NotHighlighted;
            if (Color == Resource.White)
            {
                PicturePath = Directory.GetCurrentDirectory() + Resource.PicturesPath + FigureType.PictureWhitePath;
            }
            else if (Color == Resource.Black)
            {
                PicturePath = Directory.GetCurrentDirectory() + Resource.PicturesPath + FigureType.PictureBlackPath;
            }
            else
            {
                PicturePath = Directory.GetCurrentDirectory() + Resource.PicturesPath + FigureType.PictureNeutralPath;
            }
        }

        /// <summary>
        /// Tries to play the position if it is your turn
        /// </summary>
        /// <param name="position"></param>
        public bool TryPlay(Position position)
        {
            if (Session.WhooseTurn != Color) return false;
            var enemy = Session.GetFigureAtPosition(position);
            if (CanMove(enemy))
            {
                Session.MoveFigureToPosition(Position, position);
                Position = position;
                return true;
            }
            if (enemy.Color != Color && CanAttack(enemy))
            {
                if (FigureType.MovingWhileAttacking && TryAttack(Session.GetFigureAtPosition(position)))
                {
                    Session.MoveFigureToPosition(Position, position);
                    Position = position;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if can move at position of figure
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public bool CanMove(BaseFigure figure) => figure.FigureType.UnitName == Resource.Nothing && FigureType.CanMove(this, figure);

        /// <summary>
        /// Checks if can attack enemy
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public bool CanAttack(BaseFigure enemy)
        {
            if (FigureType.CanAttack(this, enemy) && enemy.FigureType.Defence < FigureType.Attack)
            {
                if (FigureType.MovingWhileAttacking)
                {
                    var remainingHp = enemy.RemainedHpOfAttacked(this);
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
            var remainingHp = enemy.RemainedHpOfAttacked(this);
            if (FigureType.MovingWhileAttacking)
            {
                if (remainingHp > 0) return false;
                AttackPattern(enemy.Position);
                return true;
            }
            AttackPattern(enemy.Position);
            return true;
        }

        /// <summary>
        /// Attacks each figure of pattern
        /// </summary>
        /// <param name="attackedPosition"></param>
        public void AttackPattern(Position attackedPosition)
        {
            foreach (var position in FigureType.AttackPattern)
            {
                AttackFigure(Session.GetFigureAtPosition(position.AddPositions(attackedPosition)));
            }
        }

        /// <summary>
        /// Attacks figure if Hp is lesser 0 figure dies
        /// </summary>
        /// <param name="attackedFigure"></param>
        /// <returns></returns>
        public void AttackFigure(BaseFigure attackedFigure)
        {
            attackedFigure.Hp = attackedFigure.RemainedHpOfAttacked(this);
            if (attackedFigure.Hp <= 0)
            {
                attackedFigure.Die();
            }
        }

        /// <summary>
        /// Returnes remaining hp of attacked unit
        /// </summary>
        /// <param name="attackingUnit"></param>
        public int RemainedHpOfAttacked(BaseFigure attackingUnit)
        {
            double bonus = 1;
            if (FigureType.UnitType == attackingUnit.FigureType.Bonus)
            {
                bonus = Bonus;
            }
            else if (FigureType.UnitType == attackingUnit.FigureType.AntiBonus)
            {
                bonus = AntiBonus;
            }
            return Hp - (int)(attackingUnit.FigureType.Attack * bonus) - FigureType.Defence;
        }

        /// <summary>
        /// Kills unit and empties his field
        /// </summary>
        public void Die()
        {
            Session.KillFigureAtPosition(Position);
            if (Session.WhitePlayer.Color == Color)
            {
                Session.WhitePlayer.KillFigure(this);
            }
            else
            {
                Session.BlackPlayer.KillFigure(this);
            }
        }

        
    }
}
