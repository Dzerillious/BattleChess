using System.Collections.Generic;
using System.Linq;
using BattleChess3.Core;
using BattleChess3.UI.ViewModel;

namespace BattleChess3.UI.Services
{
    public class PlayerService
    {
        public List<Player> Players;
        public Player CurrentPlayer = new Player(0);

        public Player GetPlayer(int id) => Players.First(player => player.Id == id);
    }
}