using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.DefaultFigures;

public class DefaultFigureGroup : IFigureGroup
{
    public string ShownName => CurrentLocalization.Instance[$"{nameof(DefaultFigureGroup)}_Name"];

    public IFigureType[] FigureTypes => new IFigureType[]
    {
        Palm.Instance,
        Empty.Instance,
        Stone.Instance,
    };
}
