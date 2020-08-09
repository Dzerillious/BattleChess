using BattleChess3.Core.Figures;

namespace BattleChess3.SilmarillionFigures
{
    class FigureGroup : IFigureGroup
    {
        public string Name => "Silmarillion";

        public IFigureType[] GroupFigures => new IFigureType[]
        {
            new ManweMelkor(),
            new UlmoAncalagon(),
            new AuleGothmog(),
            new ElfOrc(),
            new IrmoUngoliant(),
            new NiennaBalrog(),
            new OromeCarcharoth(),
            new VardaSauron(),
            new YavannaGlaurung(),
        };
    }
}
