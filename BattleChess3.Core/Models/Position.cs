namespace BattleChess3.Core.Models
{
    public struct Position
    {
        public static readonly Position Invalid = new Position(-1, -1);
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool InBounds() => X >= 0 && X < 8 && Y >= 0 && Y < 8;

        public override bool Equals(object obj)
        {
            if (!(obj is Position pos)) return false;
            return pos.X == X && pos.Y == Y;
        }

        public static bool operator ==(Position left, Position right)
            => left.X == right.X && left.Y == right.Y;

        public static bool operator !=(Position left, Position right)
            => left.X != right.X || left.Y != right.Y;
        
        public static Position operator +(Position left, Position right)
            => new Position(left.X + right.X, left.Y + right.Y);
        
        public static Position operator -(Position left, Position right)
            => new Position(left.X - right.X, left.Y - right.Y);
        
        public static Position operator *(Position left, Position right)
            => new Position(left.X * right.X, left.Y * right.Y);
        
        public static Position operator *(Position left, int right)
            => new Position(left.X * right, left.Y * right);
        
        public static implicit operator int(Position position) 
            => position.X * 8 + position.Y;
        
        public static implicit operator Position(int i) 
            => new Position(i / 8, i % 8);
        
        public static implicit operator Position((int i, int j) pos) 
            => new Position(pos.i, pos.j);

        public bool Equals(Position other) => X == other.X && Y == other.Y;

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString() => $"({Y},{X})";
    }
}