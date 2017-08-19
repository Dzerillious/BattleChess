using System;
using System.Linq;

namespace BattleChess3.Figures.AttackingTypes
{
    public class SimpleAttackFigure : SimpleMoveFigure
    {
        public Func<Position, Position, Position[], bool> CanAttackSimple => (figurePosition, attackPosition, avaibleAttacks) =>
        {
            return avaibleAttacks.Any(avaibleAttack => avaibleAttack.CheckIfSame(attackPosition.SubstractPositions(figurePosition)));
        };
    }
}
