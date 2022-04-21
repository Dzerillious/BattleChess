using BattleChess3.Core.Resources;

namespace BattleChess3.Core.Model;

public readonly struct Position
{
    public static readonly Position None = new(-1, -1);
    public int X { get; }
    public int Y { get; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
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
        => new Position(left.X + right.X, left.Y + right.Y);
    
    public static Position operator -(Position left, Position right)
        => new Position(left.X - right.X, left.Y - right.Y);
    
    public static Position operator *(Position left, Position right)
        => new Position(left.X * right.X, left.Y * right.Y);
    
    public static Position operator *(Position left, int right)
        => new Position(left.X * right, left.Y * right);
    
    public static implicit operator int(Position position) 
        => position.Y * Constants.BoardLength + position.X;
    
    public static implicit operator Position(int i) 
        => new Position(i % Constants.BoardLength, i / Constants.BoardLength);
    
    public static implicit operator Position((int x, int y) pos) 
        => new Position(pos.x, pos.y);


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

    public Position GetPlayerPOVPosition(in Player currentPlayer)
       => (currentPlayer.Id % 4) switch
       {
           1 => new Position(X, Constants.BoardLength - Y - 1),
           2 => new Position(X, Y),
           3 => new Position(Y, X),
           0 => new Position(Constants.BoardLength - Y - 1, X),
           _ => throw new System.ArgumentOutOfRangeException(),
       };

    public override string ToString() => $"({X},{Y})";
}
