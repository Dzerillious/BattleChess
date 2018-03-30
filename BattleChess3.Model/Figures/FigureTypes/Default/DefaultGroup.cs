using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleChess3.Model.Figures.FigureTypes.Default
{
    class DefaultGroup : IFIgureGroup
    {
        public string Name => "Default";

        public IFigure[] GroupFigures => new IFigure[]
        {
            new Ninja(),
            new Nothing(),
            new Palm(),
            new Stone(),
        };
    }
}
