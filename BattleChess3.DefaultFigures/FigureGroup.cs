using BattleChess3.Core.Figures;

namespace BattleChess3.DefaultFigures
{
    public class FigureGroup : IFigureGroup
    {
        public string Name => "Default";
        public static Empty Empty { get; } = new Empty();
        public static Ninja Ninja { get; } = new Ninja();
        public static Palm Palm { get; } = new Palm();
        public static Stone Stone { get; } = new Stone();

        public IFigureType[] GroupFigures => new IFigureType[]
        {
            Palm,
            Empty,
            Ninja,
            Stone,
        };
    }
}
