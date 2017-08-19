using System;
using System.Linq;

namespace BattleChess3.Figures.AttackingTypes
{
    public class SimpleMoveFigure
    {
        public Func<Position, Position, Position[], bool> CanMoveSimple => (figurePosition, movePosition, avaibleMoves) =>
        {
            return avaibleMoves.Any(avaibleMove => avaibleMove.CheckIfSame(movePosition.SubstractPositions(figurePosition)));
        };
    }
}
