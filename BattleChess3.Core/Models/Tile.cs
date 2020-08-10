namespace BattleChess3.Core.Models
{
    public class Tile
    {
        public static Tile Invalid { get; } = new Tile();
        public virtual Position Position { get; set; } = Position.Invalid;
        public virtual Figure Figure { get; set; }
    }
}