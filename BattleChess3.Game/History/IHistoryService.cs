using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.Game.History;

public interface IHistoryService
{
    public IReadOnlyCollection<RecordedAction> RecordedActions { get; }

    public void RecordAction(
        Position sourcePosition,
        Position targetPosition,
        Figure figure,
        RecordedActionType actionType);

    public bool CanRevertAction();

    public void RevertLastAction(IBoard board);
}