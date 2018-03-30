using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleChess3.Model.Figures.FigureTypes.LordOfTheRings
{
    class LOTRGroup : IFIgureGroup
    {
        public string Name => "LOTR";

        public IFigure[] GroupFigures => new IFigure[]
        {
            new LOTRAS(),
            new LOTRGW(),
            new LOTRFG(),
            new LOTRGN(),
            new LOTRLN(),
            new LOTRMT(),
            new LOTRPT(),
            new LOTRSO(),
            new LOTRSS(),
        };
    }
}
