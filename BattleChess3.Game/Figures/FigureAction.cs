using BattleChess3.Game.Board;

namespace BattleChess3.Game.Figures;

public class FigureAction
{
    public static readonly FigureAction None = new(FigureActionTypes.None, Position.None, Position.None, () => { });

    public FigureAction(
        FigureActionTypes actionType,
        Position sourcePosition,
        Position targetPosition,
        Action action)
    {
        ActionType = actionType;
        SourcePosition = sourcePosition;
        TargetPosition = targetPosition;
        Action = action;
    }

    public Position SourcePosition { get; }
    public Position TargetPosition { get; }
    public FigureActionTypes ActionType { get; }
    public Action Action { get; }
}