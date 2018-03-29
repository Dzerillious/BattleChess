using BattleChess3.Model.Figures;
using BattleChess3.Model.Figures.FigureTypes;
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
        /// <summary>
        /// Array of Figure types
        /// </summary>
        public static readonly IFigure[] FigureTypes =
        {
            new LOTRAS(),
            new LOTRFG(),
            new LOTRGN(),
            new LOTRGW(),
            new LOTRLN(),
            new LOTRMT(),
            new LOTRPT(),
            new LOTRSO(),
            new LOTRSS(),
            new SilmarillionAG(),
            new SilmarillionEO(),
            new SilmarillionIU(),
            new SilmarillionMM(),
            new SilmarillionNB(),
            new SilmarillionNC(),
            new SilmarillionUA(),
            new SilmarillionVS(),
            new SilmarillionYG(),
            new HobbitHelper(),
            new HobbitLeader(),
            new HobbitMinorWizzard(),
            new HobbitRingBearer(),
            new HobbitSoldier(),
            new HobbitWarrior(),
            new HobbitWizzard(),
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