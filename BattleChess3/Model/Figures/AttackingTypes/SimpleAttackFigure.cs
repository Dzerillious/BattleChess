using System;
using System.Linq;

namespace BattleChess3.GameData.Figures.AttackingTypes
{
    /// <summary>
    /// Class of simple attack of figure
    /// </summary>
    public class SimpleAttackFigure : SimpleMoveFigure
    {
        /// <summary>
        /// Checks if position is one of possible attacking positions
        /// </summary>
        public Func<BaseFigure, BaseFigure, Position[], bool> CanAttackSimple => (figure, attackFigure, avaibleAttacks) =>
        {
            return avaibleAttacks.Any(avaibleAttack => avaibleAttack.CheckIfSame(attackFigure.Position.SubstractPositions(figure.Position)));
        };
    }
}