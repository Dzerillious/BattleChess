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
        public IFigureType FigureTypeType { get; set; }
        public int Hp { get; set; } = 0;
        public bool Clicked { get; set; } = false;
        public string Highlighted { get; set; } = "";
        public string PicturePath { get; set; } = "";
        public double Bonus { get; private set; } = 2;
        public double AntiBonus { get; private set; } = 0.5;


        public Figure(IFigureType figureTypeType)
        {
            FigureTypeType = figureTypeType;
        }

        /// <summary>
        /// Constructor of baseFigure
        /// </summary>
        public Figure(Player owner, IFigureType figureTypeType)
        {
            Hp = 100;
            Owner = owner;
            FigureTypeType = figureTypeType;
            Highlighted = Directory.GetCurrentDirectory() + "Pictures\\Nothing.png";
            PicturePath = GetFigurePicturePath(figureTypeType, owner.Id);
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
        public int RemainingHpOfAttacked(Figure attackingUnit)
        {
            double bonus = 1;
            if (FigureTypeType.UnitTypes == attackingUnit.FigureTypeType.Bonus)
            {
                bonus = Bonus;
            }
            else if (FigureTypeType.UnitTypes == attackingUnit.FigureTypeType.AntiBonus)
            {
                bonus = AntiBonus;
            }
            return Hp - (int)(attackingUnit.FigureTypeType.Attack * bonus) - FigureTypeType.Defence;
        }
    }
}