using BattleChess3.DefaultFigures.Localization;
using BattleChess3.Game.Figures;

namespace BattleChess3.DefaultFigures;

internal interface IDefaultFigureType : IFigureType
{
    string IFigureType.UnitName => $"{nameof(DefaultFigureGroup)}.{GetType().Name}";
    string IFigureType.DisplayName => CurrentLocalization.Instance[$"{GetType().Name}_{nameof(DisplayName)}"];
    string IFigureType.Description => CurrentLocalization.Instance[$"{GetType().Name}_{nameof(Description)}"];

    IDictionary<int, Uri> IFigureType.ImageUris =>
        new Dictionary<int, Uri>
        {
            { 0, new Uri($"pack://application:,,,/BattleChess3.DefaultFigures;component/Images/{GetType().Name}0.png", UriKind.Absolute) }
        };
}