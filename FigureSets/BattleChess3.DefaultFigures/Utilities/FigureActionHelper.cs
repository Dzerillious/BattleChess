using BattleChess3.Core.Model;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.DefaultFigures.Utilities;

public static class FigureActionHelper
{
    public static void MoveToTile(this ITile unitTile, ITile targetTile)
    {
        targetTile.Figure = unitTile.Figure;
        unitTile.Figure = new Figure(Player.Neutral, Empty.Instance);
    }

    public static void CreateFigure(this ITile targetTile, Figure createdFiure)
    {
        targetTile.Figure = createdFiure;
        targetTile.Figure.Owner.Figures.Add(targetTile.Figure);
    }

    public static void KillFigureWithoutMove(this ITile unitTile, ITile targetTile)
    {
        targetTile.Figure.Owner.Figures.Remove(targetTile.Figure);
        targetTile.Figure = new Figure(Player.Neutral, Empty.Instance);
    }

    public static void KillFigureWithMove(this ITile unitTile, ITile targetTile)
    {
        targetTile.Figure.Owner.Figures.Remove(targetTile.Figure);
        targetTile.Figure = new Figure(Player.Neutral, Empty.Instance);
        unitTile.MoveToTile(targetTile);
    }

    public static void SwapWithTile(this ITile unitTile, ITile targetTile)
    {
        var tmp = targetTile.Figure;
        targetTile.Figure = unitTile.Figure;
        unitTile.Figure = tmp;
    }

    public static void PassTurn(this ITile tile)
    {
    }

    public static bool CanKill(this ITile unitTile, ITile targetTile)
    {
        if (unitTile.Figure.Owner.Equals(targetTile.Figure.Owner))
            return false;

        return targetTile.Figure.Hp - unitTile.Figure.AttackCalculation(targetTile.Figure) <= 0;
    }
}
