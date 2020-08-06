using System.Collections.Generic;
using BattleChess3.Core.Figures;

namespace BattleChess3.Core
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
    }
}