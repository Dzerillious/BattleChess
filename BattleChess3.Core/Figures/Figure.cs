using BattleChess3.Core.Figures.FigureTypes.Default;
using System;
using System.IO;
using BattleChess3.Core.Resources;

namespace BattleChess3.Core.Figures
{
    /// <summary>
    /// Class for each figure
    /// </summary>
    public class Figure
    {
        public static Figure Empty { get; }
            = new Figure
            {
                Hp = 100,
                Owner = Player.Neutral,
                FigureType = new Nothing(),
                Highlighted = Directory.GetCurrentDirectory() + "Pictures\\Nothing.png",
                PicturePath = new Nothing().PictureNeutralPath
            };
        
        public Player Owner;
        public IFigure FigureType { get; set; }
        public int Hp { get; set; }
        public bool Clicked { get; set; } = false;
        public string Highlighted { get; set; } = "";
        public string PicturePath { get; set; } = "";
        public double Bonus { get; private set; } = 2;
        public double AntiBonus { get; private set; } = 0.5;
        

        public Figure()
        {
            
        }

        /// <summary>
        /// Constructor of baseFigure
        /// </summary>
        public Figure(Player owner, IFigure figureType)
        {
            Hp = 100;
            Owner = owner;
            FigureType = figureType;
            Highlighted = Directory.GetCurrentDirectory() + "Pictures\\Nothing.png";
            if (Owner.Id == 1)
            {
                PicturePath = FigureType.PictureWhitePath;
            }
            else if (Owner.Id == 2)
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
        public bool CanMove(Figure figure, Func<Position, Figure> getFigureAtPosition)
            => figure.FigureType.UnitName == "Nothing" && FigureType.CanMove(this, figure, getFigureAtPosition);

        /// <summary>
        /// Checks if can attack enemy
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public bool CanAttack(Figure enemy, Func<Position, Figure> getFigureAtPosition)
        {
            if (!FigureType.CanAttack(this, enemy, getFigureAtPosition) 
                || enemy.FigureType.Defence >= FigureType.Attack) return false;
            if (!FigureType.MovingWhileAttacking) return true;
            
            var remainingHp = enemy.RemainingHpOfAttacked(this);
            return remainingHp <= 0;
        }

        /// <summary>
        /// Returns remaining hp of attacked unit
        /// </summary>
        /// <param name="attackingUnit"></param>
        public int RemainingHpOfAttacked(Figure attackingUnit)
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