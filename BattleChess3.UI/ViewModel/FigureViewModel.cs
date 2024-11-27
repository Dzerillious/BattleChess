using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.UI.ViewModel;

public sealed class FigureViewModel : IFigureType
{
    private readonly Func<ITile, IBoard, IEnumerable<FigureAction>> _getActionsFunc;

    public FigureViewModel(IFigureType figureType)
    {
        _getActionsFunc = figureType.GetPossibleActions;

        DisplayName = figureType.DisplayName;
        Description = figureType.Description;
        UnitName = figureType.UnitName;
        ImageUris = figureType.ImageUris;
    }

    public string DisplayName { get; }
    public string Description { get; }
    public string UnitName { get; }
    public IDictionary<int, Uri> ImageUris { get; }
    
    public IEnumerable<FigureAction> GetPossibleActions(ITile unitTile, IBoard board)
    {
        return _getActionsFunc.Invoke(unitTile, board);
    }
}