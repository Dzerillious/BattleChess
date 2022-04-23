using BattleChess3.Core.Model;

namespace BattleChess3.CrossFireFigures.Utilities
{
    internal static class CrossFireActionHelper
    {
        public static bool CanKill(this ITile unitTile, ITile targetTile)
        {
            if (targetTile.Figure.UnitName == Wall.Instance.UnitName)
            {
                return targetTile.Figure.Owner == unitTile.Figure.Owner;
            }
            else if (unitTile.Figure.Owner.Equals(targetTile.Figure.Owner))
            {
                return false;
            }
            else
            {
                return targetTile.Figure.Hp - unitTile.Figure.AttackCalculation(targetTile.Figure) <= 0;
            }
        }
    }
}
