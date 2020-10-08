using BattleChess3.Core.Figures;

namespace BattleChess3.SilmarillionFigures
{
    public class SilmarillionFigureGroup : IFigureGroup
    {
        public string ShownName => "Silmarillion";

        public IFigureType[] GroupFigures => new IFigureType[]
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
}
