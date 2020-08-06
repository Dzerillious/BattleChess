namespace BattleChess3.Core.Figures.FigureTypes.Hobbit
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
