using BattleChess3.Core.Resources;

namespace BattleChess3.Core.Model
{
    public readonly struct Position
    {
        public static readonly Position None = new Position(-1, -1);
        public int Y { get; }
        public int X { get; }

        public Position(int y, int x)
        {
            Y = y;
            X = x;
        }

        public bool InBoard() => X >= 0 
                              && Y >= 0
                              && X < Constants.BoardLength 
                              && Y < Constants.BoardLength;

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
            => position.Y * Constants.BoardLength + position.X;
        
        public static implicit operator Position(int i) 
            => new Position(i / Constants.BoardLength, i % Constants.BoardLength);
        
        public static implicit operator Position((int y, int x) pos) 
            => new Position(pos.y, pos.x);


        public override bool Equals(object? obj)
        {
            if (!(obj is Position pos)) return false;
            return Equals(pos);
        }
        
        public bool Equals(Position other) => X == other.X && Y == other.Y;

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString() => $"({Y},{X})";

        public Position GetPlayerPOVRelative(in Player currentPlayer) 
            => (currentPlayer.Id % 4) switch
            {
                0 => new Position(-Y, X),
                1 => this,
                2 => new Position(-X, Y),
                3 => new Position(X, Y),
                _ => this
            };

        public Position GetPlayerPOVPosition(in Player currentPlayer) 
            => (currentPlayer.Id % 4) switch
            {
                0 => new Position(Constants.BoardLength - Y - 1, X),
                1 => this,
                2 => new Position(Constants.BoardLength - X - 1, Y),
                3 => new Position(X, Y),
                _ => this
            };
    }
}