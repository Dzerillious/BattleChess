using System.Collections.Generic;
using System.Linq;
using BattleChess3.Core.Models;

namespace BattleChess3.UI.Services
{
    public class PlayerService
    {
        public List<Player> Players = new List<Player>();
        public Player CurrentPlayer = new Player(0);
        public Player GetPlayer(int id) => Players[id];

        public void InitializePlayers(in int playersCount, in int currentPlayer)
        {
            Players.Clear();
            for (var i = 0; i < playersCount + 1; i++)
                Players.Add(new Player(i));
            CurrentPlayer = Players[currentPlayer];
        }
    }
}