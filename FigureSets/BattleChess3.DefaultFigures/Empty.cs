using BattleChess3.DefaultFigures.Localization;
using BattleChess3.Game.Board;
using BattleChess3.Game.Figures;

namespace BattleChess3.DefaultFigures;

public class Empty : IEmptyFigureType
{
    string IFigureType.DisplayName => CurrentLocalization.Instance[$"{GetType().Name}_{nameof(IFigureType.DisplayName)}"];
    string IFigureType.Description => CurrentLocalization.Instance[$"{GetType().Name}_{nameof(IFigureType.Description)}"];

    IDictionary<int, Uri> IFigureType.ImageUris =>
        new Dictionary<int, Uri>
        {
            { 0, new Uri($"pack://application:,,,/BattleChess3.DefaultFigures;component/Images/{GetType().Name}0.png", UriKind.Absolute) }
        };

    public IEnumerable<FigureAction> GetPossibleActions(ITile unitTile, IBoard board)
    {
        return Array.Empty<FigureAction>();
    }
}