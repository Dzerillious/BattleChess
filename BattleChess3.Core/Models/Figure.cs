using System;
using System.IO;
using BattleChess3.Core.Figures;

namespace BattleChess3.Core.Models
{
    /// <summary>
    /// Class for each figure
    /// </summary>
    public class Figure
    {
        public Player Owner = Player.Neutral;
        public IFigureType FigureType { get; set; }
        public double Hp { get; set; } = 0;

        public Figure(IFigureType figureType)
        {
            FigureType = figureType;
        }

        /// <summary>
        /// Constructor of baseFigure
        /// </summary>
        public Figure(Player owner, IFigureType figureType)
        {
            Hp = 100;
            Owner = owner;
            FigureType = figureType;
        }

        public static string GetFigurePicturePath(IFigureType figureType, int id)
            => $"{Directory.GetCurrentDirectory()}\\Pictures\\{figureType.GroupName}\\{figureType.UnitName}{id}";

        /// <summary>
        /// Check if can move at position of figure
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public bool CanMove(Figure figure, Func<Tile, Figure> getFigureAtPosition)
        {
            return false;
            // return figure.FigureType.UnitName == "Nothing" && FigureType.CanMove(this, figure, getFigureAtPosition);
        }

        /// <summary>
        /// Checks if can attack enemy
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public bool CanAttack(Figure enemy, Func<Position, Figure> getFigureAtPosition)
        {
            return false;
            // if (!FigureType.CanAttack(this, enemy, getFigureAtPosition) 
            //     || enemy.FigureType.Defence >= FigureType.Attack) return false;
            // if (!FigureType.MovingAttack) return true;
            //
            // var remainingHp = enemy.RemainingHpOfAttacked(this);
            // return remainingHp <= 0;
        }

        /// <summary>
        /// Returns remaining hp of attacked unit
        /// </summary>
        /// <param name="attackingUnit"></param>
        public double RemainingHpOfAttacked(Figure attackingUnit)
        {
            double bonus = 1;
            if (FigureType.UnitTypes == attackingUnit.FigureType.Bonus)
            {
                bonus = 2;
            }
            else if (FigureType.UnitTypes == attackingUnit.FigureType.AntiBonus)
            {
                bonus = 0.5;
            }
            return Hp - (attackingUnit.FigureType.Attack * bonus) - FigureType.Defence;
        }
    }
}