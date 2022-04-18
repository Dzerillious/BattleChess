using System.Collections.Generic;
using BattleChess3.Core.Model.Figures;

namespace BattleChess3.Core.Model;

public class Player
{
    public static readonly Player Neutral = new(0);
    
    public int Id { get; }
    public List<Figure> Figures { get; } = new List<Figure>();

    public Player(int id)
    {
        Id = id;
    }

    public override string ToString() => $"Player{Id}";
}
