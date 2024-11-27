using BattleChess3.Game.Figures;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures;

public class LordOfTheRingsFigureGroup : IFigureGroup
{
    public static readonly IFigureType AragornSauron = new AragornSauron();
    public static readonly IFigureType GandalfWitchKing = new GandalfWitchKing();
    public static readonly IFigureType FrodoGollum = new FrodoGollum();
    public static readonly IFigureType GimliNazgul = new GimliNazgul();
    public static readonly IFigureType LegolasNazgul = new LegolasNazgul();
    public static readonly IFigureType MerryTroll = new MerryTroll();
    public static readonly IFigureType PipinTroll = new PipinTroll();
    public static readonly IFigureType SoldierOrc = new SoldierOrc();
    public static readonly IFigureType SamSaruman = new SamSaruman();
    public string DisplayName => CurrentLocalization.Instance[$"{nameof(LordOfTheRingsFigureGroup)}_Name"];

    public IFigureType[] FigureTypes =>
        new[]
        {
            AragornSauron,
            GandalfWitchKing,
            FrodoGollum,
            GimliNazgul,
            LegolasNazgul,
            MerryTroll,
            PipinTroll,
            SoldierOrc,
            SamSaruman
        };
}