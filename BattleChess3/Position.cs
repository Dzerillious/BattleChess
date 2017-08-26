namespace BattleChess3
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position() {}
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Check if position is in board
        /// </summary>
        /// <returns></returns>
        public bool CheckIfInBoard()
        {
            return X >= 0 && X < 8 && Y >= 0 && Y < 8;
        }

        /// <summary>
        /// Check if positions are the same
        /// </summary>
        /// <param name="position">Checked position</param>
        /// <returns></returns>
        public bool CheckIfSame(Position position) => X == position.X && Y == position.Y;

        /// <summary>
        /// Check if positions are the same
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <returns></returns>
        public bool CheckIfSame(int x, int y) => X == x && Y == y;

        /// <summary>
        /// Adds one position to another
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Position AddPositions(Position position) => new Position(X+position.X, Y+position.Y);

        /// <summary>
        /// Substracts one position from another
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Position SubstractPositions(Position position) => new Position(X - position.X, Y - position.Y);
        
        /// <summary>
        /// Multiplies one position with koeficient
        /// </summary>
        /// <param name="koeficient"></param>
        /// <returns></returns>
        public Position MultiplePosition(int koeficient) => new Position(X * koeficient, Y * koeficient);
    }
}
