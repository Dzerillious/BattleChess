namespace BattleChess3.Core.Figures.FigureTypes.Silmarillion
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
