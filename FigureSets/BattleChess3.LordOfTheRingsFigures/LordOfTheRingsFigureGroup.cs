using BattleChess3.Core.Model.Figure;
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
            SoldierOrc.Instance,
            SamSaruman.Instance,
        };
    }
}
