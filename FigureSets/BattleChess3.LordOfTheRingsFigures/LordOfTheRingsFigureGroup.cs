using BattleChess3.Core.Model.Figures;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures;

public class LordOfTheRingsFigureGroup : IFigureGroup
{
    public string ShownName => CurrentLocalization.Instance[$"{nameof(LordOfTheRingsFigureGroup)}_Name"];

    public IFigureType[] FigureTypes => new IFigureType[]
    {
        AragornSauron.Instance,
        GandalfWitchKing.Instance,
        FrodoGollum.Instance,
        GimliNazgul.Instance,
        LegolasNazgul.Instance,
        MerryTroll.Instance,
        PipinTroll.Instance,
        SoldierOrc.Instance,
        SamSaruman.Instance,
    };
}
