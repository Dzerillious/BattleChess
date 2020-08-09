using BattleChess3.Core.Figures;

namespace BattleChess3.ChessFigures
{
    public class FigureGroup : IFigureGroup
    {
        public string Name => "Chess";

        public IFigureType[] GroupFigures => new IFigureType[]
        {
            new King(),
            new Queen(),
            new Tower(),
            new Bishop(),
            new Horse(),
            new Pawn(),
        };
    }
}
