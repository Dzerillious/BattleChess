using BattleChess3.Properties;
using System;
using System.Linq;

namespace BattleChess3.GameData.Figures.AttackingTypes
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
            if (movingFigure.Color == Resource.White && movingFigure.Position.Y < moveToFigure.Position.Y)
            {
                return false;
            }
            else if (movingFigure.Color == Resource.Black && movingFigure.Position.Y > moveToFigure.Position.Y)
            {
                return false;
            }
            return avaibleMoves.Any(avaibleMove => avaibleMove.CheckIfSame(moveToFigure.Position.SubstractPositions(movingFigure.Position)));
        };
    }
}