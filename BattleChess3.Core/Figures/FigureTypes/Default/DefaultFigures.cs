namespace BattleChess3.Core.Figures.FigureTypes.Default
{
    class DefaultFigures : IFIgureGroup
    {
        public string Name => "Default";
        public static Nothing Nothing { get; } = new Nothing();
        public static Ninja Ninja { get; } = new Ninja();
        public static Palm Palm { get; } = new Palm();
        public static Stone Stone { get; } = new Stone();

        public IFigure[] GroupFigures => new IFigure[]
        {
            Palm,
            Nothing,
            Ninja,
            Stone,
        };
    }
}
