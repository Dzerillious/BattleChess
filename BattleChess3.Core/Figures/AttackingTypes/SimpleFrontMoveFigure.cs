using System;
using System.Linq;

namespace BattleChess3.Core.Figures.AttackingTypes
{
    /// <summary>
    /// Class of simple front move of figure
    /// </summary>
    public class SimpleFrontMoveFigure
    {
        /// <summary>
        /// Checks if position is one of possible moving positions
        /// </summary>
        public Func<BaseFigure, BaseFigure, Position[], bool> CanMoveSimple => (movingFigure, moveToFigure, avaibleMoves) =>
        {
            if (movingFigure.PlayerNumber == 1 && movingFigure.Position.Y > moveToFigure.Position.Y)
            {
                return false;
            }
            else if (movingFigure.PlayerNumber == 2 && movingFigure.Position.Y < moveToFigure.Position.Y)
            {
                return false;
            }
            return avaibleMoves.Any(avaibleMove => avaibleMove == moveToFigure.Position.SubstractPositions(movingFigure.Position));
        };
    }
}