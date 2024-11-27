using BattleChess3.ChessFigures.Localization;
using BattleChess3.Game.Figures;

namespace BattleChess3.ChessFigures;

internal interface IChessFigureType : IFigureType
{
    string IFigureType.UnitName => $"{nameof(ChessFigureGroup)}.{GetType().Name}";
    string IFigureType.DisplayName => CurrentLocalization.Instance[$"{GetType().Name}_Name"];
    string IFigureType.Description => CurrentLocalization.Instance[$"{GetType().Name}_{nameof(Description)}"];

    IDictionary<int, Uri> IFigureType.ImageUris =>
        new Dictionary<int, Uri>
        {
            { 1, new Uri($"pack://application:,,,/BattleChess3.ChessFigures;component/Images/{GetType().Name}1.png", UriKind.Absolute) },
            { 2, new Uri($"pack://application:,,,/BattleChess3.ChessFigures;component/Images/{GetType().Name}2.png", UriKind.Absolute) }
        };
}