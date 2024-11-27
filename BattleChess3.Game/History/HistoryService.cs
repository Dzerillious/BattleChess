using System.Collections.Immutable;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.Game.History;

internal class HistoryService : IHistoryService
{
    private readonly IFigureCreator _figureCreator;
    private readonly IList<RecordedAction> _recordedActions = new List<RecordedAction>();

    public HistoryService(
        IFigureCreator figureCreator)
    {
        _figureCreator = figureCreator;
    }

    public IReadOnlyCollection<RecordedAction> RecordedActions => _recordedActions.ToImmutableArray();
    
    public void RecordAction(
        Position sourcePosition,
        Position targetPosition,
        Figure figure,
        RecordedActionType actionType)
    {
        _recordedActions.Add(new RecordedAction(sourcePosition, targetPosition, figure, actionType));
    }

    public bool CanRevertAction()
    {
        return RecordedActions.Count > 0;
    }

    public void RevertLastAction(IBoard board)
    {
        do
        {
            RevertLastAction(board);
        } while (_recordedActions.Count > 0 &&
                 _recordedActions[^1].ActionType != RecordedActionType.UserInput);
    }

    private void RevertLastActionPart(IBoard board)
    {
        var action = _recordedActions[^1];
        _recordedActions.RemoveAt(RecordedActions.Count - 1);
        
        switch (action.ActionType)
        {
            case RecordedActionType.Moved:
            {
                var sourceTile = board[action.SourcePosition];
                var targetTile = board[action.TargetPosition];
                (sourceTile.Figure, targetTile.Figure) = (targetTile.Figure, sourceTile.Figure);
                break;
            }
            case RecordedActionType.Created:
            {
                var targetTile = board[action.TargetPosition];
                targetTile.Figure.Owner.Figures.Remove(targetTile.Figure);
                targetTile.Figure = _figureCreator.CreateEmptyFigure();
                break;
            }
            case RecordedActionType.Destroyed:
            {
                var targetTile = board[action.TargetPosition];
                targetTile.Figure = _figureCreator.CreateFigure(action.FigureIdentifier);
                break;
            }
        }
    }
}