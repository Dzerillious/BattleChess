using BattleChess3.Core.Model.Figures;
using BattleChess3.DefaultFigures.Localization;

namespace BattleChess3.CrossFireFigures;

public class CrossFireFigureGroup : IFigureGroup
{
    public string ShownName => CurrentLocalization.Instance[$"{nameof(CrossFireFigureGroup)}_Name"];

    public IFigureType[] FigureTypes => new IFigureType[]
    {
        Ninja.Instance,
        Bomber.Instance,
        Builder.Instance,
        Knight.Instance,
        Spy.Instance,
        Archer.Instance,
        Wall.Instance
    };
}
