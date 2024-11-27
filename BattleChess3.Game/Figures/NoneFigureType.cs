using BattleChess3.Game.Board;

namespace BattleChess3.Game.Figures;

public class NoneFigureType : IFigureType
{
    public static NoneFigureType Instance { get; } = new();

    public string DisplayName => string.Empty;
    public string Description => string.Empty;
    public string UnitName => string.Empty;
    public IDictionary<int, Uri> ImageUris { get; } = new Dictionary<int, Uri>();
    
    public IEnumerable<FigureAction> GetPossibleActions(ITile unitTile, IBoard board)
    {
        return Array.Empty<FigureAction>();
    }
}