using BattleChess3.Core.Figures;
using BattleChess3.LordOfTheRingsFigures.Localization;

namespace BattleChess3.LordOfTheRingsFigures
{
    public class LordOfTheRingsFigureGroup : IFigureGroup
    {
        public string ShownName => CurrentLocalization.Instance["LordOfTheRingsFigureGroup_Name"];

        public IFigureType[] GroupFigures => new IFigureType[]
        {
            AragornSauron.Instance,
            GandalfWitchKing.Instance,
            FrodoGollum.Instance,
            GimliNazgul.Instance,
            LegolasNazgul.Instance,
            MerryTroll.Instance,
            PipinTroll.Instance,
            SoldierOrk.Instance,
            SamSaruman.Instance,
        };
    }
}
