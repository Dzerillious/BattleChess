using BattleChess3.Model.Figures;
using BattleChess3.Model.Figures.FigureTypes.Default;
using BattleChess3.Model.Figures.FigureTypes.ClassicChess;
using BattleChess3.Model.Figures.FigureTypes.LordOfTheRings;
using BattleChess3.Model.Figures.FigureTypes.Hobbit;
using BattleChess3.Model.Figures.FigureTypes.Silmarillion;
using System.Linq;

namespace BattleChess3.Model
{
    /// <summary>
    /// Has field of all types of figures and works with it
    /// </summary>
    public static class TypesOfFigures
    {
        public static readonly IFIgureGroup LOTRGroup = new LOTRGroup();
        public static readonly IFIgureGroup SilmarillionGroup = new SilmarillionGroup();
        public static readonly IFIgureGroup HobbitGroup = new HobbitGroup();
        public static readonly IFIgureGroup ClassicChessGroup = new ClassicChessGroup();
        public static readonly IFIgureGroup DefaultGroup = new DefaultGroup();

        public static readonly IFIgureGroup[] FigureGroups =
        {
            new LOTRGroup(),
            new SilmarillionGroup(),
            new HobbitGroup(),
            new ClassicChessGroup(),
            new DefaultGroup(),
        };

        /// <summary>
        /// Gets first figure which name is given string
        /// </summary>
        public static IFigure GetFigureFromString(string text) => FigureGroups.FirstOrDefault(group => group.GroupFigures.FirstOrDefault(figure => figure.UnitName == text) != null)
            .GroupFigures.FirstOrDefault(figure => figure.UnitName == text);
    }
}