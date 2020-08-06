using BattleChess3.Core.Figures;

namespace BattleChess3.Core
{
    public class Tile
    {
        public static Tile Invalid { get; } = new Tile();
        public virtual Position Position { get; set; } = Position.Invalid;
        public virtual Figure Figure { get; set; } = Figure.Empty;
    }
}