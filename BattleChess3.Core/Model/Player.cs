using System.Collections.Generic;

namespace BattleChess3.Core.Model
{
    public class Player
    {
        public static readonly Player Neutral = new Player(-1);
        
        public int Id { get; }
        public List<Figure.Figure> Figures { get; } = new List<Figure.Figure>();

        public Player(int id)
        {
            Id = id;
        }

        public override string ToString() => $"Player{Id}";
    }
}