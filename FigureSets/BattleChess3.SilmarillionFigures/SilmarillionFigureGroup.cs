using BattleChess3.Core.Model.Figures;
using BattleChess3.SilmarillionFigures.Localization;

namespace BattleChess3.SilmarillionFigures;

public class SilmarillionFigureGroup : IFigureGroup
{
    public string ShownName => CurrentLocalization.Instance[$"{nameof(SilmarillionFigureGroup)}_Name"];

    public IFigureType[] FigureTypes => new IFigureType[]
    {
        ManweMelkor.Instance,
        UlmoAncalagon.Instance,
        AuleGothmog.Instance,
        ElfOrc.Instance,
        IrmoUngoliant.Instance,
        NiennaBalrog.Instance,
        OromeCarcharoth.Instance,
        VardaSauron.Instance,
        YavannaGlaurung.Instance,
    };
}
