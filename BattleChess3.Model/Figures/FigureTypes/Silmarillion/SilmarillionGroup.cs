using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleChess3.Model.Figures.FigureTypes.Silmarillion
{
    class SilmarillionGroup : IFIgureGroup
    {
        public string Name => "Silmarillion";

        public IFigure[] GroupFigures => new IFigure[]
        {
            new SilmarillionMM(),
            new SilmarillionUA(),
            new SilmarillionAG(),
            new SilmarillionEO(),
            new SilmarillionIU(),
            new SilmarillionNB(),
            new SilmarillionNC(),
            new SilmarillionVS(),
            new SilmarillionYG(),
        };
    }
}
