using BattleChess3.Model.Figures.FigureTypes;
using BattleChess3.Shared;
using BattleChess3.Shared.Properties;
using System;
using System.IO;

namespace BattleChess3.Model.Figures
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
        /// Constructor of empty figure
        /// </summary>
        public BaseFigure()
        {
            Hp = 100;
            Color = Resource.Neutral;
            Position = new Position();
            FigureType = new Nothing();
            Highlighted = Directory.GetCurrentDirectory() + "Pictures\\Nothing.png";
            PicturePath = FigureType.PictureNeutralPath;
        }

        /// <summary>
        /// Constructor of nothing at position
        /// </summary>
        public BaseFigure(Position position)
        {
            Hp = 100;
            Color = Resource.Neutral;
            Position = position;
            FigureType = new Nothing();
            Highlighted = Directory.GetCurrentDirectory() + "Pictures\\Nothing.png";
            PicturePath = FigureType.PictureNeutralPath;
        }

        /// <summary>
        /// Constructor of baseFigure
        /// </summary>
        public BaseFigure(string color, Position position, IFigure figureType)
        {
            Hp = 100;
            Color = color;
            Position = position;
            FigureType = figureType;
            Highlighted = Directory.GetCurrentDirectory() + "Pictures\\Nothing.png";
            if (Color == Resource.White)
            {
                PicturePath = FigureType.PictureWhitePath;
            }
            else if (Color == Resource.Black)
            {
                PicturePath = FigureType.PictureBlackPath;
            }
            else
            {
                PicturePath = FigureType.PictureNeutralPath;
            }
        }

        /// <summary>
        /// Check if can move at position of figure
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public bool CanMove(BaseFigure figure, Func<Position, BaseFigure> getFigureAtPosition) 
            => figure.FigureType.UnitName == Resource.Nothing && FigureType.CanMove(this, figure, getFigureAtPosition);

        /// <summary>
        /// Checks if can attack enemy
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public bool CanAttack(BaseFigure enemy, Func<Position, BaseFigure> getFigureAtPosition)
        {
            if (FigureType.CanAttack(this, enemy, getFigureAtPosition) && enemy.FigureType.Defence < FigureType.Attack)
            {
                if (FigureType.MovingWhileAttacking)
                {
                    var remainingHp = enemy.RemainingHpOfAttacked(this);
                    return remainingHp <= 0;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns remaining hp of attacked unit
        /// </summary>
        /// <param name="attackingUnit"></param>
        public int RemainingHpOfAttacked(BaseFigure attackingUnit)
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
    }
}