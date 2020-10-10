namespace BattleChess3.Core.Models
{
    public class Tile
    {
        public static readonly Tile Invalid = new Tile();
        
        public virtual Position Position { get; } = Position.Invalid;
        public virtual Figure Figure { get; set; }
        
        public virtual bool IsMouseOver { get; set; }
        public virtual bool IsSelected { get; set; }
        public virtual bool IsPossibleMove { get; set; }
        public virtual bool IsPossibleAction { get; set; }

        public override string ToString() => $"{Figure}";
    }
}