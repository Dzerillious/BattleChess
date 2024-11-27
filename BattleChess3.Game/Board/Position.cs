using BattleChess3.Game.Players;

namespace BattleChess3.Game.Board;

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

    public bool IsInBoard()
    {
        return X >= 0
               && Y >= 0
               && X < IBoard.Length
               && Y < IBoard.Length;
    }

    public bool IsOutsideBoard()
    {
        return !IsInBoard();
    }

    public static bool operator ==(Position left, Position right)
    {
        return left.X == right.X && left.Y == right.Y;
    }

    public static bool operator !=(Position left, Position right)
    {
        return left.X != right.X || left.Y != right.Y;
    }

    public static Position operator +(Position left, Position right)
    {
        return new Position(left.X + right.X, left.Y + right.Y);
    }

    public static Position operator -(Position left, Position right)
    {
        return new Position(left.X - right.X, left.Y - right.Y);
    }

    public static Position operator *(Position left, Position right)
    {
        return new Position(left.X * right.X, left.Y * right.Y);
    }

    public static Position operator *(Position left, int right)
    {
        return new Position(left.X * right, left.Y * right);
    }

    public static Position operator *(int left, Position right)
    {
        return new Position(left * right.X, left * right.Y);
    }

    public static implicit operator int(Position position)
    {
        return position.Y * IBoard.Length + position.X;
    }

    public static implicit operator Position(int i)
    {
        return new Position(i % IBoard.Length, i / IBoard.Length);
    }

    public static implicit operator Position((int x, int y) pos)
    {
        return new Position(pos.x, pos.y);
    }

    public static implicit operator (int, int)(Position position)
    {
        return (position.X, position.Y);
    }

    public override bool Equals(object? obj)
    {
        return obj is Position pos && Equals(pos);
    }

    private bool Equals(Position other)
    {
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (X * 397) ^ Y;
        }
    }

    public Position GetPlayerPOVPosition(in Player currentPlayer)
    {
        return (currentPlayer.Id % 4) switch
        {
            1 => new Position(X, IBoard.Length - Y - 1),
            2 => new Position(X, Y),
            3 => new Position(Y, X),
            0 => new Position(IBoard.Length - Y - 1, X),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public override string ToString()
    {
        return $"({X},{Y})";
    }
}