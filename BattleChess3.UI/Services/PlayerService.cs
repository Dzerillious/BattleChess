using System.Collections.Generic;
using BattleChess3.Core.Model;

namespace BattleChess3.UI.Services;

public class PlayerService
{
    public readonly List<Player> Players = new List<Player>();
    
    public Player CurrentPlayer = Player.Neutral;
    public Player GetPlayer(int id) => Players[id + 1];

    public void InitializePlayers(in int playersCount, in int currentPlayer)
    {
        Players.Clear();
        for (int i = -1; i < playersCount; i++)
            Players.Add(new Player(i));
        CurrentPlayer = GetPlayer(currentPlayer);
    }

    public void NextTurn()
    {
        int nextId = (CurrentPlayer.Id + 1) % (Players.Count - 1);
        CurrentPlayer = GetPlayer(nextId);
    }
}
