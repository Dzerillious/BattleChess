using System;
using System.Linq;
using BattleChess3.Properties;

namespace BattleChess3.GameData.Figures.AttackingTypes
{
    /// <summary>
    /// Class of simple front attack of figure
    /// </summary>
    public class SimpleFrontAttackFigure : SimpleFrontMoveFigure
    {
        /// <summary>
        /// Checks if position is one of possible attacking positions
        /// </summary>
        public Func<BaseFigure, BaseFigure, Position[], bool> CanAttackSimple =>
            (attackingFigure, attackedFigure, avaibleAttacks) =>
            {
                if (attackingFigure.Color == Resource.White && attackingFigure.Position.Y > attackedFigure.Position.Y)
                {
                    return false;
                }
                else if (attackingFigure.Color == Resource.Black && attackingFigure.Position.Y < attackedFigure.Position.Y)
                {
                    return false;
                }
                return avaibleAttacks.Any(avaibleAttack =>
                    avaibleAttack.CheckIfSame(attackedFigure.Position.SubstractPositions(attackingFigure.Position)));
            };
    }
}