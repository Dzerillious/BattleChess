namespace BattleChess3
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position() {}
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
        /// Check if positions are the same
        /// </summary>
        public bool CheckIfSame(Position position) => X == position.X && Y == position.Y;

        /// <summary>
        /// Check if positions are the same
        /// </summary>>
        public bool CheckIfSame(int x, int y) => X == x && Y == y;

        /// <summary>
        /// Adds one position to another
        /// </summary>
        public Position AddPositions(Position position) => new Position(X+position.X, Y+position.Y);

        /// <summary>
        /// Substracts one position from another
        /// </summary>
        public Position SubstractPositions(Position position) => new Position(X - position.X, Y - position.Y);
        
        /// <summary>
        /// Multiplies one position with koeficient
        /// </summary>
        public Position MultiplePosition(int koeficient) => new Position(X * koeficient, Y * koeficient);
    }
}
