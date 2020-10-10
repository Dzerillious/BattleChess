namespace BattleChess3.Core.Models
{
    public struct Position
    {
        public static readonly Position Invalid = new Position(-1, -1);
        public int Y { get; }
        public int X { get; }

        public Position(int y, int x)
        {
            Y = y;
            X = x;
        }

        public bool InBoard() => X >= 0 && X < 8 && Y >= 0 && Y < 8;

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
            => new Position(left.Y + right.Y, left.X + right.X);
        
        public static Position operator -(Position left, Position right)
            => new Position(left.Y - right.Y, left.X - right.X);
        
        public static Position operator *(Position left, Position right)
            => new Position(left.Y * right.Y, left.X * right.X);
        
        public static Position operator *(Position left, int right)
            => new Position(left.Y * right, left.X * right);
        
        public static implicit operator int(Position position) 
            => position.Y * 8 + position.X;
        
        public static implicit operator Position(int i) 
            => new Position(i / 8, i % 8);
        
        public static implicit operator Position((int x, int y) pos) 
            => new Position(pos.y, pos.x);

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