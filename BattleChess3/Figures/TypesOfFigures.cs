using System.Linq;
using BattleChess3.Figures.FigureTypes;
using BattleChess3.Figures.FigureTypes.ClassicChess;

namespace BattleChess3.Figures
{
    /// <summary>
    /// Has field of all types of figures and works with it
    /// </summary>
    public static class TypesOfFigures 
    {
        /// <summary>
        /// Array of Figure types
        /// </summary>
        public static readonly IFigure[] FigureTypes =
        {
            new Ninja(),
            new ChessHorse(), 
            new ChessKing(),
            new ChessQueen(), 
            new ChessBishop(), 
            new ChessPawn(), 
            new ChessTower(), 
            new Nothing(),
            new Palm(),
            new Stone(), 
        };

        /// <summary>
        /// Gets figure type from name of type
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IFigure GetFigureFromString(string text) => FigureTypes.FirstOrDefault(figure => figure.UnitName == text);
    }
}
