using System;
using System.Linq;

namespace BattleChess3.Core.Figures.AttackingTypes
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
                if (attackingFigure.PlayerNumber == 1 && attackingFigure.Position.Y > attackedFigure.Position.Y)
                {
                    return false;
                }
                else if (attackingFigure.PlayerNumber == 2 && attackingFigure.Position.Y < attackedFigure.Position.Y)
                {
                    return false;
                }
                return avaibleAttacks.Any(avaibleAttack =>
                    avaibleAttack == attackedFigure.Position.SubstractPositions(attackingFigure.Position));
            };
    }
}