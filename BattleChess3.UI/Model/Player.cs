using System.Collections.Generic;
using BattleChess3.Core.Figures;

namespace BattleChess3.UI.Model
{
    public class Player
    {
        public int PlayerNumber { get; }
        public List<BaseFigure> Figures { get; } = new List<BaseFigure>();

        public Player(int playerNumber)
        {
            PlayerNumber = playerNumber;
        }
    }
}