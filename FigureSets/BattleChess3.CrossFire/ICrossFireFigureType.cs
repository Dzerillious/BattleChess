using BattleChess3.CrossFireFigures.Localization;
using BattleChess3.Game.Figures;

namespace BattleChess3.CrossFireFigures;

internal interface ICrossFireFigureType : IFigureType
{
    string IFigureType.UnitName => $"{nameof(CrossFireFigureGroup)}.{GetType().Name}";
    string IFigureType.DisplayName => CurrentLocalization.Instance[$"{GetType().Name}_{nameof(DisplayName)}"];
    string IFigureType.Description => CurrentLocalization.Instance[$"{GetType().Name}_{nameof(Description)}"];

    IDictionary<int, Uri> IFigureType.ImageUris =>
        new Dictionary<int, Uri>
        {
            { 1, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{GetType().Name}1.png", UriKind.Absolute) },
            { 2, new Uri($"pack://application:,,,/BattleChess3.CrossFireFigures;component/Images/{GetType().Name}2.png", UriKind.Absolute) }
        };
}