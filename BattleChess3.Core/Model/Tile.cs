using BattleChess3.Core.Model.Figures;

namespace BattleChess3.Core.Model
{
    public class Tile
    {
        public static readonly Tile None = new Tile();
        
        public virtual Position Position { get; } = Position.None;
        public virtual Figure Figure { get; set; } = Figure.None;
        
        public virtual bool IsMouseOver { get; set; }
        public virtual bool IsSelected { get; set; }
        public virtual bool IsPossibleMove { get; set; }
        public virtual bool IsPossibleAttack { get; set; }

        public override string ToString() => $"{Position}:{Figure}";
    }
}