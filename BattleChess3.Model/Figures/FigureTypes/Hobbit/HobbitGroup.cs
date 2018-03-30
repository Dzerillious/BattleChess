using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleChess3.Model.Figures.FigureTypes.Hobbit
{
    class HobbitGroup : IFIgureGroup
    {
        public string Name => "Hobbit";

        public IFigure[] GroupFigures => new IFigure[]
        {
            new HobbitLeader(),
            new HobbitRingBearer(),
            new HobbitHelper(),
            new HobbitMinorWizzard(),
            new HobbitSoldier(),
            new HobbitWarrior(),
            new HobbitWizzard(),
        };
    }
}
