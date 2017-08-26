using System;
using System.Linq;
using BattleChess3.Game;
using BattleChess3.Properties;

namespace BattleChess3.Figures.AttackingTypes
{
    /// <summary>
    /// Class of simple move of figure
    /// </summary>
    public class DirectionMove
    {
        /// <summary>
        /// Checks if position is one of possible moving positions
        /// </summary>
        public Func<BaseFigure, BaseFigure, Position[], bool> CanMoveDirection => (movingFigure, moveToFigure, directions) =>
        {
            foreach (var direction in directions)
            {
                for (var i = 1; i < 7; i++)
                {
                    var moveToPosition = movingFigure.Position.AddPositions(direction.MultiplePosition(i));
                    if (moveToPosition.CheckIfInBoard() == false) break;
                    if (moveToPosition.CheckIfSame(moveToFigure.Position))
                    {
                        return true;
                    }
                    if (Play.GetFigureAtPosition(moveToPosition).FigureType.UnitName != Resource.Nothing)
                    {
                        break;
                    }
                }
            }
            return false;
        };
    }
}
