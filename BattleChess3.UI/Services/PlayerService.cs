using System.Collections.Generic;
using System.Linq;
using BattleChess3.Core;

namespace BattleChess3.UI.Services
{
    public class PlayerService
    {
        public List<Player> Players = new List<Player>();
        public Player CurrentPlayer = new Player(0);
        public Player GetPlayer(int id) => Players.First(player => player.Id == id);
    }
}