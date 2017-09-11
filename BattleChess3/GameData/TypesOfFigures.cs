using System.Linq;
using BattleChess3.GameData.Figures;
using BattleChess3.GameData.Figures.FigureTypes;
using BattleChess3.GameData.Figures.FigureTypes.ClassicChess;

namespace BattleChess3.GameData
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
        
        public static IFigure GetFigureFromString(string text) => FigureTypes.FirstOrDefault(figure => figure.UnitName == text);
    }
}
