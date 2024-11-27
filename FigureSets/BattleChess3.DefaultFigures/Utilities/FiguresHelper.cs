using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;
using BattleChess3.Game.Players;

namespace BattleChess3.DefaultFigures.Utilities;

public static class FiguresHelper
{
    public static bool IsEmpty(this ITile tile)
    {
        return tile.Figure.Type.Equals(DefaultFigureGroup.Empty);
    }

    public static bool IsWater(this ITile tile)
    {
        return tile.Figure.Type.Equals(DefaultFigureGroup.Water);
    }

    public static bool IsOwnedByYou(this ITile checkedTile, ITile yoursTile)
    {
        return checkedTile.Figure.Owner.Equals(yoursTile.Figure.Owner);
    }

    public static bool IsOwnedByEnemy(this ITile checkedTile, ITile yoursTile)
    {
        return !checkedTile.Figure.Owner.Equals(Player.Neutral) &&
               !checkedTile.Figure.Owner.Equals(yoursTile.Figure.Owner);
    }

    public static void CreateFigure(this ITile tile, Figure createdFigure, IBoard board)
    {
        tile.Figure = createdFigure;
        tile.Figure.Owner.Figures.Add(tile.Figure);
        tile.Figure.Type.OnCreated(board);
    }

    public static void Die(this ITile tile, IBoard board)
    {
        var figureType = tile.Figure.Type;
        figureType.OnDying(tile, board); 
        tile.Figure.Owner.Figures.Remove(tile.Figure);
        tile.Figure = new Figure(Player.Neutral, DefaultFigureGroup.Empty);
        figureType.OnDied(tile, board);
    }

    public static void MoveToTile(this ITile from, ITile to, IBoard board)
    {
        var figureType = from.Figure.Type; 
        figureType.OnMoving(from, to, board);
        (to.Figure, from.Figure) = (from.Figure, to.Figure);
        figureType.OnMoved(from, to, board);
    }

    public static void KillWithoutMove(this ITile from, ITile to, IBoard board)
    {
        var attackingFigure = from.Figure.Type; 
        var killedFigure = to.Figure.Type;
        
        attackingFigure.OnAttacking(from, to, board);
        killedFigure.OnDying(to, board);
        killedFigure.OnBeingAttacked(to, from, board);
        
        to.Figure.Owner.Figures.Remove(to.Figure);
        to.Figure = new Figure(Player.Neutral, DefaultFigureGroup.Empty);
        
        killedFigure.OnDied(to, board);
        killedFigure.OnKilled(to, from, board);
        attackingFigure.OnAttacked(from, to, board);
    }

    public static void KillWithMove(this ITile from, ITile to, IBoard board)
    {
        var attackingFigure = from.Figure.Type; 
        var killedFigure = to.Figure.Type;
        
        attackingFigure.OnMoving(from, to, board);
        attackingFigure.OnAttacking(from, to, board);
        killedFigure.OnDying(to, board);
        killedFigure.OnBeingAttacked(to, from, board);
        
        to.Figure.Owner.Figures.Remove(to.Figure);
        to.Figure = from.Figure;
        from.Figure = new Figure(Player.Neutral, DefaultFigureGroup.Empty);
        
        attackingFigure.OnMoved(from, to, board);
        killedFigure.OnDied(to, board);
        killedFigure.OnKilled(to, from, board);
        attackingFigure.OnAttacked(from, to, board);
    }
}