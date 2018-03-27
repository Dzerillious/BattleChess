using BattleChess3.Model.Figures;
using BattleChess3.Model.Figures.FigureTypes;
using BattleChess3.Model.Figures.FigureTypes.ClassicChess;
using System.Linq;

namespace BattleChess3.Model
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
        /// Gets first figure which name is given string
        /// </summary>
        public static IFigure GetFigureFromString(string text) => FigureTypes.FirstOrDefault(figure => figure.UnitName == text);
    }
}