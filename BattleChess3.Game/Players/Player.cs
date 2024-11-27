using BattleChess3.Game.Figures;

namespace BattleChess3.Game.Players;

public class Player : IEquatable<Player>
{
    public static readonly Player Neutral = new(0);

    public Player(int id)
    {
        Id = id;
    }

    public int Id { get; }
    public List<Figure> Figures { get; } = new();

    public bool Equals(Player? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id == other.Id;
    }

    public override string ToString()
    {
        return $"Player{Id}";
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((Player)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }
}