using BattleChess3.Game.Figures;
using BattleChess3.SpyFigures.Localization;

namespace BattleChess3.SpyFigures;

internal interface ISpyFigureType : IFigureType
{
    string IFigureType.UnitName => $"{nameof(SpyFigureGroup)}.{GetType().Name}";
    string IFigureType.DisplayName => CurrentLocalization.Instance[$"{GetType().Name}_Name"];
    string IFigureType.Description => CurrentLocalization.Instance[$"{GetType().Name}_{nameof(Description)}"];

    IDictionary<int, Uri> IFigureType.ImageUris =>
        new Dictionary<int, Uri>
        {
            { 1, new Uri($"pack://application:,,,/BattleChess3.SpyFigures;component/Images/{GetType().Name}1.png", UriKind.Absolute) },
            { 2, new Uri($"pack://application:,,,/BattleChess3.SpyFigures;component/Images/{GetType().Name}2.png", UriKind.Absolute) }
        };
}