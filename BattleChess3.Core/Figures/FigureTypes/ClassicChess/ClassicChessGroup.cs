namespace BattleChess3.Core.Figures.FigureTypes.ClassicChess
{
    public class ClassicChessGroup : IFIgureGroup
    {
        public string Name => "Chess";

        public IFigure[] GroupFigures => new IFigure[]
        {
            new ChessKing(),
            new ChessQueen(),
            new ChessTower(),
            new ChessBishop(),
            new ChessHorse(),
            new ChessPawn(),
        };
    }
}
