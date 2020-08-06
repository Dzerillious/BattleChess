namespace BattleChess3.Core.Figures.FigureTypes.Default
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
