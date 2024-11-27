using BattleChess3.Game.Figures;
using BattleChess3.StarWarsFigures.Localization;

namespace BattleChess3.StarWarsFigures;

internal interface IStarWarsFigureType : IFigureType
{
    string IFigureType.UnitName => $"{nameof(StarWarsFigureGroup)}.{GetType().Name}";
    string IFigureType.DisplayName => CurrentLocalization.Instance[$"{GetType().Name}_Name"];
    string IFigureType.Description => CurrentLocalization.Instance[$"{GetType().Name}_{nameof(Description)}"];

    IDictionary<int, Uri> IFigureType.ImageUris =>
        new Dictionary<int, Uri>
        {
            { 1, new Uri($"pack://application:,,,/BattleChess3.StarWarsFigures;component/Images/{GetType().Name}1.png", UriKind.Absolute) },
            { 2, new Uri($"pack://application:,,,/BattleChess3.StarWarsFigures;component/Images/{GetType().Name}2.png", UriKind.Absolute) }
        };
}