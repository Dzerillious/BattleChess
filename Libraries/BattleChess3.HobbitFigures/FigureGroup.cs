using BattleChess3.Core.Figures;

namespace BattleChess3.HobbitFigures
{
    public class FigureGroup : IFigureGroup
    {
        public string Name => "Hobbit";

        public IFigureType[] GroupFigures => new IFigureType[]
        {
            new Leader(),
            new RingBearer(),
            new Helper(),
            new MinorWizzard(),
            new Soldier(),
            new Warrior(),
            new Wizzard(),
        };
    }
}
