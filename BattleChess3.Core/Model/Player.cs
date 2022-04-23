using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.Core.Model;

public class Player : IEqualityComparer<Player>
{
    public static readonly Player Neutral = new(0);
    
    public int Id { get; }
    public List<Figure> Figures { get; } = new List<Figure>();

    public Player(int id)
    {
        Id = id;
    }

    public override string ToString() => $"Player{Id}";

    public bool Equals(Player? x, Player? y)
    {
        if (x is null)
            return y is null;

        if (y is null)
            return false;

        return x.Id == y.Id;
    }

    public int GetHashCode([DisallowNull] Player obj)
    {
        return obj.Id.GetHashCode();
    }
}
