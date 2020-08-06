using BattleChess3.Core.Figures.FigureTypes.Default;
using System;
using System.IO;

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
                FigureType = Nothing.Instance,
                Highlighted = Directory.GetCurrentDirectory() + "Pictures\\Nothing.png",
                PicturePath =  GetPicturePath(Nothing.Instance, 0)
            };
        
        public Player Owner = Player.Neutral;
        public IFigure FigureType { get; set; } = Nothing.Instance;
        public int Hp { get; set; } = 0;
        public bool Clicked { get; set; } = false;
        public string Highlighted { get; set; } = "";
        public string PicturePath { get; set; } = "";
        public double Bonus { get; private set; } = 2;
        public double AntiBonus { get; private set; } = 0.5;
        

        public Figure() {}

        /// <summary>
        /// Constructor of baseFigure
        /// </summary>
        public Figure(Player owner, IFigure figureType)
        {
            Hp = 100;
            Owner = owner;
            FigureType = figureType;
            Highlighted = Directory.GetCurrentDirectory() + "Pictures\\Nothing.png";
            PicturePath = GetPicturePath(figureType, owner.Id);
        }

        private static string GetPicturePath(IFigure figure, int id)
            => $"{Directory.GetCurrentDirectory()}\\Pictures\\{figure.GroupName}\\{figure.UnitName}{id}";

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