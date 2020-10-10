namespace BattleChess3.Core.Model
{
    public class Tile
    {
        public static readonly Tile Invalid = new Tile();
        
        public virtual Position Position { get; } = Position.Invalid;
        public virtual Figure.Figure Figure { get; set; } = Model.Figure.Figure.Empty;
        
        public virtual bool IsMouseOver { get; set; }
        public virtual bool IsSelected { get; set; }
        public virtual bool IsPossibleMove { get; set; }
        public virtual bool IsPossibleAttack { get; set; }

        public override string ToString() => $"{Figure}";
    }
}