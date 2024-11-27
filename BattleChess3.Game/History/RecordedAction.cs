using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.Game.History;

public class RecordedAction
{
    // JSON serializable
    public RecordedAction()
    {
    }

    public RecordedAction(
        Position sourcePosition,
        Position targetPosition,
        Figure figure,
        RecordedActionType actionType)
    {
        SourcePosition = sourcePosition;
        TargetPosition = targetPosition;
        FigureIdentifier = new FigureIdentifier(figure);
        ActionType = actionType;
    }

    public Position SourcePosition { get; set; }
    public Position TargetPosition { get; set; }
    public FigureIdentifier FigureIdentifier { get; set; }
    public RecordedActionType ActionType { get; set; }
}