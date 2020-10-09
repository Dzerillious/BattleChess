using System.Collections.Generic;

namespace BattleChess3.Core.Models
{
    public class Player
    {
        public static readonly Player Neutral = new Player(0);
        
        public int Id { get; }
        public List<Figure> Figures { get; } = new List<Figure>();

        public Player(int id)
        {
            Id = id;
        }

        public override string ToString() => $"Player{Id}";
    }
}