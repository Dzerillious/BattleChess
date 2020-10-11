using BattleChess3.Core.Model.Figures;

namespace BattleChess3.SilmarillionFigures
{
    public class SilmarillionFigureGroup : IFigureGroup
    {
        public string ShownName => "Silmarillion";

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
}
