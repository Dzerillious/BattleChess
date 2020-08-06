namespace BattleChess3.Core
{
    public struct Position
    {
        public static readonly Position Invalid = new Position(-1, -1);
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool CheckIfInBoard()
        {
            return X >= 0 && X < 8 && Y >= 0 && Y < 8;
        }

        /// <summary>
        /// Adds one position to another
        /// </summary>
        public Position AddPositions(Position position) => new Position(X + position.X, Y + position.Y);

        /// <summary>
        /// Substracts one position from another
        /// </summary>
        public Position SubstractPositions(Position position) => new Position(X - position.X, Y - position.Y);

        /// <summary>
        /// Multiplies one position with koeficient
        /// </summary>
        public Position MultiplePosition(int koeficient) => new Position(X * koeficient, Y * koeficient);

        public override bool Equals(object obj)
        {
            if (!(obj is Position pos)) return false;
            return pos.X == X && pos.Y == Y;
        }

        public static bool operator ==(Position left, Position right)
            => left.X == right.X && left.Y == right.Y;

        public static bool operator !=(Position left, Position right)
            => left.X != right.X || left.Y != right.Y;

        public bool Equals(Position other) => X == other.X && Y == other.Y;

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}