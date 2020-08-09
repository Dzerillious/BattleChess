using BattleChess3.Core.Figures;
using BattleChess3.LordOfTheRingsFigures;

namespace BattleChess3.LordOfTheRings
{
    class FigureGroup : IFigureGroup
    {
        public string Name => "LOTR";

        public IFigureType[] GroupFigures => new IFigureType[]
        {
            new AragornSauron(),
            new GandalfWitchKing(),
            new FrodoGollum(),
            new GimliNazgul(),
            new LegolasNazgul(),
            new MerryTroll(),
            new PipinTroll(),
            new SoldierOrk(),
            new SamSaruman(),
        };
    }
}
