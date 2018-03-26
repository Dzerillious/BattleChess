using BattleChess3.Properties;
using System;

namespace BattleChess3.GameData.Figures.AttackingTypes
{
    /// <summary>
    /// Class of simple move of figure
    /// </summary>
    public class DirectionAttack : DirectionMove
    {
        /// <summary>
        /// Checks if position is one of possible moving positions
        /// </summary>
        public Func<BaseFigure, BaseFigure, Position[], bool> CanAttackDirection => (movingFigure, moveToFigure, directions) =>
        {
            foreach (var direction in directions)
            {
                for (var i = 1; i < 8; i++)
                {
                    var moveToPosition = movingFigure.Position.AddPositions(direction.MultiplePosition(i));
                    if (moveToPosition.CheckIfInBoard() == false) break;
                    if (moveToPosition.CheckIfSame(moveToFigure.Position))
                    {
                        return true;
                    }
                    if (Game.Session.GetFigureAtPosition(moveToPosition).FigureType.UnitName != Resource.Nothing)
                    {
                        break;
                    }
                }
            }
            return false;
        };
    }
}